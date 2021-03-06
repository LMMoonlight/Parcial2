using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour, IChangeObject
{
    [SerializeField] public Material chaMaterial; // Material a cambiar
    [SerializeField] public Material defMaterial; //Material default
    public List<MeshRenderer> renders = new List<MeshRenderer>(); //Lista para almacenar los renders de cada obj en MO.
    bool hasChanged = false; //Bool sobre si ha cambiado el objeto de textura.
    public ManageObjects MO { get; set; } //Ref al ManageObjects

    public void HandleObject() //Metodo que se llama desde change Color
    {
        CheckObjects(); //Checkee que objetos se cambiara el color
        foreach (MeshRenderer render in renders) //Para cada render
        {
            if (!hasChanged) ChangeColor(render, chaMaterial); //si no se han cambiado todos siga cambiando colores.
            else ChangeColor(render, defMaterial); //Si ya se cambio y se preciona denuevo el boton, regreselos al original.
        }
        hasChanged = !hasChanged;
    }
    public void CheckObjects()
    {
        renders.Clear(); //Limpie la lista de Renders antes de agregarlos
        foreach (GameObject obj in MO.objects) //agregue solo los rendes de los objetos dentro de MO
        {
            renders.Add(obj.GetComponent<MeshRenderer>());
        }
    }
    public void ChangeColor(MeshRenderer render, Material material)
    {
        render.material = material;
    }
}
