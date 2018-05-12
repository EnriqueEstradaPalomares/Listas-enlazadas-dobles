using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listas_enlazadas_dobles
{
    class Inventario
    {
        private Producto inicio = null;
        public void agregar(Producto nuevo)
        {

            if (inicio == null)
            {
                inicio = nuevo;
            }
            else if (Buscar(nuevo.Codigo, inicio) == null)
            {
                if (nuevo.Codigo < inicio.Codigo)
                {
                    Producto temp = inicio;
                    inicio = nuevo;
                    inicio.sig = temp;
                    temp.ant = inicio;
                }
                else
                {
                    Agregar(inicio, nuevo);
                }
            }
        }

        private void Agregar(Producto posicion, Producto nuevo)
        {
            if (nuevo.Codigo > posicion.Codigo && posicion.sig == null)
            {
                posicion.sig = nuevo;
                posicion.sig.ant = posicion;
            }

            else if (nuevo.Codigo < posicion.Codigo)
            {
                //temp = posicion;
                posicion.ant.sig = nuevo;
                //nuevo.Siguiente = temp;
                nuevo.sig = posicion;
                //temp.Anterior = nuevo;
                posicion.ant = nuevo;
            }
            else
                Agregar(posicion.sig, nuevo);
        }

        private Producto Buscar(int codigo, Producto posicion)
        {
            Producto temp = posicion;
            if (posicion != null)
            {
                if (posicion.Codigo != codigo)
                {
                    temp = Buscar(codigo, posicion.sig);
                    return temp;
                }
                else
                    return temp;
            }
            else
                return null;
        }

        //----------------------------------------------------------------
        public string listar()
        {
            string texto = "";
            if (inicio != null)
                texto += Listar(inicio);
            return texto;

        }

        private string Listar(Producto posicion)
        {
            if (posicion.sig != null)
                return posicion.ToString() + Listar(posicion.sig);
            else
                return posicion.ToString();
        }
        //----------------------------------------------------------------
        public string buscar(int codigo)
        {
            string texto = "";
            Producto elemento = Buscar(codigo, inicio);
            if (elemento != null)
                texto += elemento.ToString();

            return texto;
        }
        //----------------------------------------------------------------
        public void eliminar(int codigo)
        {
            Producto elemento = Buscar(codigo, inicio);
            if (elemento != null)
            {
                if (elemento == inicio)
                    eliminarPrimero();
                else
                {
                    elemento.ant.sig = elemento.sig;
                    elemento.sig.ant = elemento.sig;
                }
            }
        }
        //----------------------------------------------------------------
        public void eliminarPrimero()
        {
            if (inicio != null)
                inicio = inicio.sig;
        }
        //----------------------------------------------------------------
        public void eliminarUltimo()
        {
            if (inicio != null)
            {
                if (inicio.sig == null)
                    inicio = null;
                else
                    eliminarUltimo(inicio);
            }
        }

        private void eliminarUltimo(Producto posicion)
        {
            if (posicion != null)
            {
                if (posicion.sig.sig == null)
                    posicion.sig = null;
                else
                    eliminarUltimo(posicion.sig);
            }
        }
        //----------------------------------------------------------------
        public string invertir()
        {
            string data = "";
            if (inicio != null)
                data = invertir(inicio);
            return data;
        }

        private string invertir(Producto prod)
        {
            if (prod.sig != null)
                return invertir(prod.sig) + prod.ToString();
            else
                return prod.ToString();
        }
    }
}
