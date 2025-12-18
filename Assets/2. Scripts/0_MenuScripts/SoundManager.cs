using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] bglist;
    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SFXPlay(string sfxName, AudioClip clip)
    {
        GameObject go = new GameObject(sfxName + "Sound");
        AudioSource audiosource = go.AddComponent<AudioSource>();
        audiosource.clip = clip; //여기까지 설정 끝남
        audiosource.Play(); //오디오 플레이 함수 호출

        Destroy(go, clip.length); //효과음 재생 끝나면 오브젝트 파괴
    }
}
