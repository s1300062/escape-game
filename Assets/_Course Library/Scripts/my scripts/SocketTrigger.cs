using UnityEngine;

public class SocketTrigger : MonoBehaviour
{
    public LightDimmer lightDimmer; // �Ώۂ̃��C�g�̎Q�Ɓi�C���X�y�N�^�[�Őݒ�j

    void OnTriggerEnter(Collider other)
    {
        // �����ɉ����ăt�B���^�\�i��: ����^�O�̕��̂Ȃǁj
        if (lightDimmer != null)
        {
            lightDimmer.TriggerLightIncrease();
        }
    }
}
