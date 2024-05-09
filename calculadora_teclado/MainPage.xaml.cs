using System;
using Xamarin.Forms;

namespace calculadora_teclado
{
    public partial class MainPage : ContentPage
    {
        public MainPage(){
            InitializeComponent();
            numeroUno = 0; numeroDos = 0; numRespuesta = 0; hayPunto = false;
            spnFirst.Text = ""; spnSecond.Text = ""; spnThird.Text = ""; lblNumber.Text = "0";
        }

        // Declaración de variables GLOBALES
        public double numeroUno = 0, numeroDos = 0, numRespuesta = 0;
        int operador = 4;
        bool hayPunto = false, unoDecimal = false, dosDecimal = false;

        // Declaración de métodos y funciones.
        private void Igualar_valores(String operando, int valor){
            bool validaLbl = lblNumber.Text.GetType() != operador.GetType();
            bool validaSpn = spnFirst.Text.GetType() != operador.GetType();
            if (numRespuesta != 0 || ((validaLbl || validaSpn) || (validaLbl && validaSpn)))
                unoDecimal = true;
            if (unoDecimal)
                numeroUno = double.Parse(lblNumber.Text);
            else
                numeroUno = int.Parse(lblNumber.Text);
            spnFirst.Text = numeroUno + " ";
            lblNumber.Text = "0";
            spnSecond.Text = operando;
            operador = valor;
            hayPunto = false;
        }

        private bool Hallar_Lleno(){
            bool estaLleno = false;
            if (spnFirst.Text == "" && spnSecond.Text == "") estaLleno = true;
            return estaLleno;
        }
        private void Ingresar_número(String numero){
            if (lblNumber.Text == "0" && numero != ".") lblNumber.Text = numero;
            else lblNumber.Text += numero;
        }

        // <---------------------------------------> //
        // <---------- BOTONES / BUTTONS ----------> //
        // <---------------------------------------> //

        // =====| BOTONES CORRESPONDIENTES A OPERACIONES Y FUNCIONES =====| //
        /* <--- Botón #1: "btnSumar" ---> */
        private void btnSumar(Object sender, EventArgs e){
            Igualar_valores("+", 0);
            if (!Hallar_Lleno())
                spnThird.Text = "";
        }

        /* <--- Botón #2: "btnRestar" ---> */
        private void btnRestar(Object sender, EventArgs e){
            Igualar_valores("-", 1);
            if (!Hallar_Lleno()) spnThird.Text = "";
        }

        /* <--- Botón #3: "btnMultiplicar" ---> */
        private void btnMultiplicar(Object sender, EventArgs e){
            Igualar_valores("*", 2);
            if (!Hallar_Lleno()) spnThird.Text = "";
        }

        /* <--- Botón #4: "btnDividir" ---> */
        private void btnDividir(Object sender, EventArgs e){
            Igualar_valores("/", 3);
            if (!Hallar_Lleno()) spnThird.Text = "";
        }

        /* <--- Botón #5: "btnFuncionAC" ---> */
        private void btnFuncionAC(Object sender, EventArgs e){
            numeroUno = 0; numeroDos = 0; numRespuesta = 0; hayPunto = false;
            spnFirst.Text = ""; spnSecond.Text = ""; spnThird.Text = ""; lblNumber.Text = "0";
        }

        /* <--- Botón #6: "btnFuncionC" ---> */
        private void btnFuncionC(Object sender, EventArgs e){
            if (lblNumber.Text.EndsWith(".")) hayPunto = false;
            if (lblNumber.Text != "0" && lblNumber.Text != "0."){
                if (double.Parse(lblNumber.Text) > 9)
                    lblNumber.Text = lblNumber.Text.Substring(0, lblNumber.Text.Length - 1);
                else lblNumber.Text = "0";
            }
            if (lblNumber.Text.EndsWith("."))
                lblNumber.Text = lblNumber.Text.Substring(0, lblNumber.Text.Length - 1);
        }

        /* <--- Botón #7: "btnIgual" ---> */
        private void btnIgual(Object sender, EventArgs e){
            if (spnFirst.Text != "" && spnSecond.Text != ""){
                spnThird.Text = " " + lblNumber.Text;
                if (dosDecimal) numeroDos = double.Parse(spnThird.Text);
                else
                    numeroDos = int.Parse(spnThird.Text);
                if (operador == 0){
                    numRespuesta = numeroUno + numeroDos;
                    lblNumber.Text = numRespuesta + "";
                }
                else if (operador == 1){
                    numRespuesta = numeroUno - numeroDos;
                    lblNumber.Text = numRespuesta + "";
                }
                else if (operador == 2){
                    numRespuesta = numeroUno * numeroDos;
                    lblNumber.Text = numRespuesta + "";
                }
                else{
                    if (numeroDos == 0) { lblNumber.Text = ("Error!"); }
                    else{
                        numRespuesta = numeroUno / numeroDos;
                        lblNumber.Text = numRespuesta + "";
                    }
                }
                numeroUno = 0; numeroDos = 0; numRespuesta = 0;
                operador = 4; unoDecimal = false; dosDecimal = false;
            }
        }

        // =====| BOTONES CORRESPONDIENTES A NÚMEROS =====| //
        /* <--- Botón #8: "btnNumUno" ---> */
        private void btnNumUno(Object sender, EventArgs e){
            Ingresar_número("1");
        }

        /* <--- Botón #9: "btnNumDos" ---> */
        private void btnNumDos(Object sender, EventArgs e){
            Ingresar_número("2");
        }

        /* <--- Botón #10: "btnNumTres" ---> */
        private void btnNumTres(Object sender, EventArgs e){
            Ingresar_número("3");
        }

        /* <--- Botón #11: "btnNumCuatro" ---> */
        private void btnNumCuatro(Object sender, EventArgs e){
            Ingresar_número("4");
        }

        /* <--- Botón #12: "btnNumCinco" ---> */
        private void btnNumCinco(Object sender, EventArgs e){
            Ingresar_número("5");
        }

        /* <--- Botón #13: "btnNumSeis" ---> */
        private void btnNumSeis(Object sender, EventArgs e){
            Ingresar_número("6");
        }

        /* <--- Botón #14: "btnNumSiete" ---> */
        private void btnNumSiete(Object sender, EventArgs e){
            Ingresar_número("7");
        }

        /* <--- Botón #15: "btnNumOcho" ---> */
        private void btnNumOcho(Object sender, EventArgs e){
            Ingresar_número("8");
        }

        /* <--- Botón #16: "btnNumNueve" ---> */
        private void btnNumNueve(Object sender, EventArgs e){
            Ingresar_número("9");
        }

        /* <--- Botón #17: "btnNumCero" ---> */
        private void btnNumCero(Object sender, EventArgs e){
            if (lblNumber.Text != "0") Ingresar_número("0");
        }

        /* <--- Botón #18: "btnPunto" ---> */
        private void btnPunto(Object sender, EventArgs e){
            if (!hayPunto){
                Ingresar_número(".");
                hayPunto = true;
            }
            if (operador == 4) unoDecimal = true;
            else dosDecimal = true;
        }
    }
}
