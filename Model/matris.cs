using System;
using System.Runtime.InteropServices;

namespace Matriz


{
    public unsafe class MatrizDispersa<T> where T : unmanaged
    {
        public int capa; //Aparece en graficacion
        public ListaEncabezado<int> filas;
        public ListaEncabezado<int> columnas;

        public MatrizDispersa(int capa)
        {
            this.capa = capa;
            filas = new ListaEncabezado<int>("Fila");
            columnas = new ListaEncabezado<int>("Columna");
        }

        public void insert(int pos_x, int pos_y, string nombre)
        {

            //Creacion del nodo interno
            NodoInterno<int>* nuevo = (NodoInterno<int>*)Marshal.AllocHGlobal(sizeof(NodoInterno<int>));


            nuevo->id = 1;
            nuevo->nombre = nombre;
            nuevo->coordenadaX = pos_x;
            nuevo->coordenadaY = pos_y;
            nuevo->arriba = null;
            nuevo->abajo = null;
            nuevo->derecha = null;
            nuevo->izquierda = null;


            NodoEncabezado<int>* nodo_X = filas.getEncabezado(pos_x);

            NodoEncabezado<int>* nodo_Y = columnas.getEncabezado(pos_y);

            if (nodo_X == null) 
            {

                filas.insertar_nodoEncabezado(pos_x);
                nodo_X = filas.getEncabezado(pos_x);


            }

            if (nodo_Y == null) 
            {

                columnas.insertar_nodoEncabezado(pos_y);
                nodo_Y = columnas.getEncabezado(pos_y);


            }

            if (nodo_X == null || nodo_Y == null)
            {
                throw new InvalidOperationException("Error al crear los encabezados.");
            }

            if (nodo_X->acceso == null)
            {
                nodo_X->acceso = nuevo;
            }
            else
            {
              
                if (nuevo->coordenadaY < nodo_X->acceso->coordenadaY) 
                {
                    nuevo->derecha = nodo_X->acceso;
                    nodo_X->acceso->izquierda = nuevo;
                    nodo_X->acceso = nuevo;
                }
                else
                {
                 
                    NodoInterno<int>* tmp = nodo_X->acceso;
                    while (tmp != null)
                    {
                        if (nuevo->coordenadaY < tmp->coordenadaY)
                        {
                            nuevo->derecha = tmp;
                            nuevo->izquierda = tmp->izquierda;
                            tmp->izquierda->derecha = nuevo;
                            tmp->izquierda = nuevo;
                            break;
                        }
                        else if (nuevo->coordenadaX == tmp->coordenadaX && nuevo->coordenadaY == tmp->coordenadaY)
                        {
                            
                            break;
                        }
                        else
                        {
                            if (tmp->derecha == null)
                            {
                                tmp->derecha = nuevo;
                                nuevo->izquierda = tmp;
                                break;
                            }
                            else
                            {
                                tmp = tmp->derecha;
                            }
                        }
                    }

                }


            }
            if (nodo_Y->acceso == null) 
            {
                nodo_Y->acceso = nuevo;
            }
            else
            {
                if (nuevo->coordenadaX < nodo_Y->acceso->coordenadaX)
                {
                    nuevo->abajo = nodo_Y->acceso;
                    nodo_Y->acceso->arriba = nuevo;
                    nodo_Y->acceso = nuevo;
                }
                else 
                {
                    NodoInterno<int>* tmp2 = nodo_Y->acceso;
                    while (tmp2 != null)
                    {
                        if (nuevo->coordenadaX < tmp2->coordenadaX)
                        {
                            nuevo->abajo = tmp2;
                            nuevo->arriba = tmp2->arriba;
                            tmp2->arriba->abajo = nuevo;
                            tmp2->arriba = nuevo;
                            break;
                        }
                        else if (nuevo->coordenadaX == tmp2->coordenadaX && nuevo->coordenadaY == tmp2->coordenadaY)
                        {
                            break;
                        }
                        else
                        {
                            if (tmp2->abajo == null)
                            {
                                tmp2->abajo = nuevo;
                                nuevo->arriba = tmp2;
                                break;
                            }
                            else
                            {
                                tmp2 = tmp2->abajo;
                            }

                        }


                    }



                }
            }



        }
        public void mostrar()
        {
            NodoEncabezado<int>* y_columna = columnas.primero;
            Console.Write("0->");

            while (y_columna != null)
            {
                Console.Write(y_columna->id + "->");
                y_columna = y_columna->siguiente;
            }
            Console.Write("\n");

            NodoEncabezado<int>* x_fila = filas.primero;
            while (x_fila != null)
            {
                NodoInterno<int>* interno = x_fila->acceso;
                Console.Write(x_fila->id + "->");

                while (interno != null)
                {
                    Console.Write(interno->nombre + "->");
                    interno = interno->derecha;

                }
                Console.Write("\n");


                x_fila = x_fila->siguiente;
            }

        }


        ~MatrizDispersa()
        {
            NodoEncabezado<int>* x_fila = filas.primero;
            while (x_fila != null)
            {
                NodoInterno<int>* interno = x_fila->acceso;
                while (interno != null)
                {
                    NodoInterno<int>* tmp = interno;
                    interno = interno->derecha;
                    if (tmp != null)
                    {
                        Marshal.FreeHGlobal((IntPtr)tmp);
                    }

                }

                NodoEncabezado<int>* tmp_fila = x_fila;
                x_fila = x_fila->siguiente;
                if (tmp_fila != null)
                {
                    Marshal.FreeHGlobal((IntPtr)tmp_fila);
                }

            }

            NodoEncabezado<int>* x_columna = columnas.primero;
            while (x_columna != null)
            {

                NodoInterno<int>* interno = x_columna->acceso;
                while (interno != null)
                {
                    NodoInterno<int>* tmp = interno;
                    interno = interno->abajo;
                    if (tmp != null)
                    {
                        Marshal.FreeHGlobal((IntPtr)tmp);
                    }

                }

                NodoEncabezado<int>* tmp_columna = x_columna;
                x_columna = x_columna->siguiente;
                if (tmp_columna != null)
                {
                    Marshal.FreeHGlobal((IntPtr)tmp_columna);
                }

            }
        }

    }
}



namespace Matriz


{
    public unsafe class ListaEncabezado<T> where T : unmanaged
    {
        public NodoEncabezado<int>* primero;
        public NodoEncabezado<int>* ultimo;
        public string tipo;
        public int size;

        public ListaEncabezado(string tipo)
        {
            primero = null;
            ultimo = null;
            this.tipo = tipo;
            size = 0;
        }

        public void insertar_nodoEncabezado(int id)
        {

            //Creacion del nodo
            NodoEncabezado<int>* nuevo = (NodoEncabezado<int>*)Marshal.AllocHGlobal(sizeof(NodoEncabezado<int>));
            if (nuevo == null)
            {
                throw new InvalidOperationException("No se pudo asignar memoria para el nuevo nodo.");
            }

            nuevo->id = id;
            nuevo->siguiente = null;
            nuevo->anterior = null;
            nuevo->acceso = null;

            size = size + 1;

            if (primero == null)
            {
                primero = nuevo;
                ultimo = nuevo;
            }
            else
            {
 
                if (nuevo->id < primero->id)
                {
                    nuevo->siguiente = primero;
                    primero->anterior = nuevo;
                    primero = nuevo;
                }
                else if (nuevo->id > ultimo->id)
                {
                    ultimo->siguiente = nuevo;
                    nuevo->anterior = ultimo;
                    ultimo = nuevo;
                }
                else
                {
                    NodoEncabezado<int>* tmp = primero;
                    while (tmp != null)
                    {
                        if (nuevo->id < tmp->id)
                        {
                            nuevo->siguiente = tmp;
                            nuevo->anterior = tmp->anterior;
                            tmp->anterior->siguiente = nuevo;
                            tmp->anterior = nuevo;
                            break;
                        }
                        else if (nuevo->id > tmp->id)
                        {
                            tmp = tmp->siguiente;
                        }
                        else
                        {
                            break;
                        }

                    }
                }
            }





        }

        public void Mostrar()
        {

            if (primero == null)
            {
                Console.WriteLine("Lista vacía.");
                return;
            }

            NodoEncabezado<int>* tmp = primero;
            while (tmp != null)
            {
                Console.WriteLine("Encabezado " + tipo + " " + Convert.ToString(tmp->id));
                tmp = tmp->siguiente;
            }
        }

        public NodoEncabezado<int>* getEncabezado(int id)
        {
            NodoEncabezado<int>* tmp = primero;
            while (tmp != null)

            {

                if (id == tmp->id)
                {

                    return tmp;
                }
                tmp = tmp->siguiente;
            }

            return null;

        }

        ~ListaEncabezado()
        {
            if (primero == null) return;

            while (primero != null)
            {
                NodoEncabezado<int>* tmp = primero;
                primero = primero->siguiente;
                Marshal.FreeHGlobal((IntPtr)tmp);

            }


        }
    }
}



namespace Matriz
{

    public unsafe struct NodoEncabezado<T> where T : unmanaged
    {
        public T id;
        
        public NodoEncabezado<T>* siguiente;
        public NodoEncabezado<T>* anterior;
        public NodoInterno<T>* acceso;

       
    }
}


namespace Matriz
{

    public unsafe struct NodoInterno<T> where T : unmanaged
    {
        public T id;
        public string nombre;
        public int coordenadaX; 
        public int coordenadaY; 
        public NodoInterno<T>* arriba;
        
        public NodoInterno<T>* abajo;
        public NodoInterno<T>* derecha; 
        public NodoInterno<T>* izquierda; 

       
    }
}