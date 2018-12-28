using UnityEngine;

public class MoveControl: MonoBehaviour
{ 
    [Header ("Movimentation Variables")]
    public float WalkVelocity = 1.5f;
    public float RotationVelocitySlower = 5;

    private GameObject objectAxisSupport;
    private Rigidbody objectRigidBody;
    private float rotationTime = 0;


    void Start()
    {
        // Esse Objeto pai criado para ser suporte na movimentação do personagem serve para que ele consiga rotacionar livremente
        // o objeto permite servir de base para que as direções estejam corretas nos angulos de rotação e translação
        GameObject temporarySupport = new GameObject("Temporary Game Objects");
        objectAxisSupport = new GameObject("Object Translation Support");
        objectAxisSupport.transform.position = this.transform.position;
        objectAxisSupport.transform.rotation = Quaternion.Euler(new Vector3(0,180,0));
        objectAxisSupport.transform.parent = temporarySupport.transform;

        // Realiza a movimentação em com do RigidBody pois facilita a collisão com outros objetos
        objectRigidBody = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Esperar o jogador rotacionar até certo ponto para fazer sua translação
        Rotation();
        if (rotationTime > 0.15f) {
            Translation();
        }
    }

    // Função responsável pelo deslocamento do personagem
    private void Translation()
    {
        // Calcula o deslocamento de acordo com o input horizontal e vertical
        // Multiplica ele pela velocidade ao longo do tempo (tempo é uma constante 0,1)
        // Normaliza o vetor de deslocamento para que a movimentação diagonal não fique mais rápida
        Vector3 displacement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * WalkVelocity * Time.deltaTime*5;

        // Calcula a posição no qual o objeto deve estar após movimentação
        // Transforma a direção do deslocamento do objecto com base nos eixos locais definidos no objecto suporte e os transforma em coordenadas globais 
        Vector3 newPosition = objectRigidBody.transform.position + objectAxisSupport.transform.TransformDirection(displacement);

        // Move o objeto para a nova posição
        objectRigidBody.MovePosition(newPosition);
    }

    // Função responsável pela rotação do personagem
    private void Rotation() {


        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) {

            // Aumenta lentamente o valor até 1 para que a rotação ocorra lentamente até que se chegue na direção desejada
            if (rotationTime < 1) {
                rotationTime += Time.deltaTime/RotationVelocitySlower;
            }

            // Calcula a direção que o objeto deve se rotacionar
            Vector3 directionVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            // Pega o angulo com seu respectivo sinal a partir da posição do objeto e a direção desejada
            // O vetor de posição do objeto está normalizado se resumindo ao seu vetor canônico (0s e 1s)
            // O vetor da direção desejada está transformado em coordenadas globais e apoiados com referência ao objeto suporte
            float angle = Vector3.SignedAngle(transform.position.normalized, objectAxisSupport.transform.TransformDirection(directionVector), Vector3.up);

            // Direção do vetor em Quaternions
            Quaternion direction = Quaternion.Euler(0, angle, 0);

            // Rotaciona o objeto na direção desejada
            objectRigidBody.MoveRotation(Quaternion.SlerpUnclamped(transform.rotation, direction, rotationTime));
             
        } else {
            
            // Se não há inputs ele zera a velocidade de rotação preparando para uma nova direção
            if (rotationTime != 0) {
                rotationTime = 0;
            }
        }

    }
}
