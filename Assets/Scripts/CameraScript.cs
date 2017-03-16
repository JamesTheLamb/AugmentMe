using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour {

    public GameObject camera_plane;

    public Button button_;

	// Use this for initialization
	void Start () {

        if(Application.isMobilePlatform)
        {
            GameObject cam_parent = new GameObject("CamParent");
            cam_parent.transform.position = this.transform.position;
            this.transform.parent = cam_parent.transform;
            cam_parent.transform.Rotate(Vector3.right, 90);
        }

        Input.gyro.enabled = true;

        button_.onClick.AddListener(OnButtonDown);

        WebCamTexture webby = new WebCamTexture();
        camera_plane.GetComponent<MeshRenderer>().material.mainTexture = webby;
        webby.Play();
	
	}

    void OnButtonDown()
    {
        GameObject bullet = Instantiate(Resources.Load("bullet", typeof(GameObject))) as GameObject;
        Rigidbody rig = bullet.GetComponent<Rigidbody>();
        bullet.transform.rotation = Camera.main.transform.rotation;
        bullet.transform.position = Camera.main.transform.position;
        rig.AddForce(Camera.main.transform.forward * 500f);
        Destroy(bullet, 3);
    }
	
	// Update is called once per frame
	void Update () {

        Quaternion cam_rotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
        this.transform.localRotation = cam_rotation;
	
	}
}
