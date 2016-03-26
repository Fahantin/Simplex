using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simplex
{
    public partial class Simplex : Form
    {
        public Simplex()
        {
            InitializeComponent();
        }

        static int VFolga, VBasica,ilimitada = 0, validar = 0;
        float[,] Matriz = new float[0, 0];
        float[,] MatrizIlimitada = new float[0, 0];
        DataTable Tabela = new DataTable();

        private void btGerarMatriz_Click(object sender, EventArgs e)
        {

            if (rdMaximizacao.Checked)
            {
                rdMinimizacao.Enabled = false;
            }
            else if (rdMinimizacao.Checked)
            {
                rdMaximizacao.Enabled = false;
            }
            else { MessageBox.Show("Selecione um tipo!", "Erro"); }


            if (rdMaximizacao.Checked || rdMinimizacao.Checked)
            {

                if (txtVFolga.Text != "" && txtVBasica.Text != "") {
                    VFolga = Convert.ToInt32(txtVFolga.Text);
                    VBasica = Convert.ToInt32(txtVBasica.Text); }

                
                //VERIFICAR MATRIZ//
                if (VFolga > 0 && VBasica > 0)
                {

                    //--INICIO DE DATAGRIDVIEW--//

                    //CRIAR TABELA
                    DataTable TabelaAux = new DataTable();
                    TabelaAux = new DataTable();


                    //TABELA RECEBE COLUNA BASE [Base]
                    TabelaAux.Columns.Add("Base", typeof(string));


                    //TABELA RECEBE COLUNAS [X, F e B]
                    for (int coluna = 1; coluna <= VBasica; coluna++)
                        TabelaAux.Columns.Add("X" + coluna, typeof(float));

                    for (int coluna = 1; coluna <= VFolga; coluna++)
                        TabelaAux.Columns.Add("F" + coluna, typeof(float));

                    TabelaAux.Columns.Add("B", typeof(float));


                    //OBJECT LINHA RECEBE QUANTIDADE DE COLUNAS
                    object[] Linha = new object[TabelaAux.Columns.Count];


                    //TABELA RECEBE QUANTIDADE DE LINHAS (FOLGA), E VALORES (TODAS)
                    for (int linha = 1; linha <= VFolga; linha++)
                    {
                        Linha[0] = ("F" + linha).ToString();
                        for (int coluna = 1; coluna <= VFolga + VBasica + 1; coluna++)
                        {
                            if (TabelaAux.Columns[coluna].ColumnName.ToString() == "F" + linha.ToString()) { Linha[coluna] = 1.0; }
                            else { Linha[coluna] = 0.0; }
                        }
                        TabelaAux.Rows.Add(Linha);
                    }


                    //TABELA RECEBE LINHA Z
                    for (int linha = VFolga; linha <= VFolga; linha++)
                    {
                        Linha[0] = ("Z").ToString();
                        for (int coluna = 1; coluna < VFolga + VBasica + 1; coluna++) { Linha[coluna] = 0.0; }
                        TabelaAux.Rows.Add(Linha);
                    }


                    tabelaMatriz.AllowUserToAddRows = false;
                    tabelaMatriz.AllowUserToOrderColumns = false;
                    tabelaMatriz.DataSource = TabelaAux;
                    tabelaMatriz.Update();
                    tabelaMatriz.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                    //--FIM DE DATAGRIDVIEW--//


                    //TABELA GLOBAL RECEBE ENDEREÇO DA TABELAAUX
                    Tabela = TabelaAux;

                    Matriz = new float[VFolga + 1, VFolga + VBasica + 1];
                    MatrizIlimitada = new float[VFolga + 1, VBasica + VFolga + 1];


                    //MATRIZAUX RECEBE VALORES DA TABELA//
                    for (int linha = 0; linha < Matriz.GetLength(0); linha++)
                    {
                        for (int coluna = 0; coluna < Matriz.GetLength(1); coluna++)
                        {
                            Matriz[linha, coluna] = float.Parse(TabelaAux.Rows[linha][coluna + 1].ToString());
                        }
                    }
                }
                else { MessageBox.Show("Matriz Inválida!", "Erro"); rdMaximizacao.Enabled = true; rdMinimizacao.Enabled = true; }
            }
        }



        //--INICIO LIMPAR TABELA--//
        private void btLimparMatriz_Click(object sender, EventArgs e)
        {
            txtVFolga.Text = String.Empty;
            txtVBasica.Text = String.Empty;
            tabelaMatriz.Columns.Clear();
            Tabela.Rows.Clear();
            Tabela.Columns.Clear();
            lstResultado.Items.Clear();
            rdMinimizacao.Enabled = true;
            rdMaximizacao.Enabled = true;
            VFolga = 0;
            VBasica = 0;
            Matriz = new float[0, 0];
            MatrizIlimitada = new float[0, 0];
            validar = 0;
            ilimitada = 0;
        }
        //--FIM LIMPAR TABELA--//



        //--INICIO DA INTERAÇÃO--//
        private void btInteracao_Click(object sender, EventArgs e)
        {
            if (rdMaximizacao.Checked)
            {
                 IteracaoMax(Matriz); 
            }
            else if(rdMinimizacao.Checked) {

               IteracaoMin(Matriz);
            }
            else
            {
                MessageBox.Show("Selecione um tipo!", "Erro");
            }
        }
        //--FIM DA INTERAÇÃO--//
        


        //-INICIO MÉTODO INTERAÇÃO MINIMIZAÇÃO--//
        public float[,] IteracaoMin(float[,] Matriz)
        {
            int LinhaPivo = 0, ColunaPivo = 0, linha = 0, coluna = 0;
            float Pivo = 0, MaiorValorZ = 0, Aux = 0, PrimeiraDivisao = 0;
            int cont = 0;
            bool igual = true;
           
                //MATRIZ RECEBE VALORES DA TABELA//
                for (linha = 0; linha < Matriz.GetLength(0); linha++)
                {
                    for (coluna = 0; coluna < Matriz.GetLength(1); coluna++)
                    {
                        Matriz[linha, coluna] = float.Parse(Tabela.Rows[linha][coluna + 1].ToString());
                    }
                }


                //CRIAR MATRIZ AUXILIAR//
                float[,] MatrizAux = new float[VFolga + 1, VBasica + VFolga + 1];


                //PASSAR VALORES DA MATRIZ PARA MATRIZ AUXILIAR//
                for (linha = 0; linha < Matriz.GetLength(0); linha++)
                {
                    for (coluna = 0; coluna < Matriz.GetLength(1); coluna++)
                    {
                        MatrizAux[linha, coluna] = Matriz[linha, coluna];
                    }
                }


                //VERIFICAR SE HÁ VALORES POSITIVOS NA LINHA Z//
                for (coluna = 0; coluna < Matriz.GetLength(1); coluna++)
                {
                    if (Matriz[(Matriz.GetLength(0) - 1), coluna] > 0) { cont = 1; }
                }

                /*if (validar == 2)
                {
                    MessageBox.Show("Matriz Ilimitada!", "Erro");
                    cont = 0;
                }*/

                if (cont != 1)
                    MessageBox.Show("Não há iterações a serem feitas!", "Erro");


                if (cont == 1)
                {

                    //MAIOR VALOR DE Z//
                    for (linha = (Matriz.GetLength(0) - 1); linha < Matriz.GetLength(0); linha++)
                    {
                        for (coluna = 0; coluna < Matriz.GetLength(1)-1; coluna++)
                        {
                            if ((Matriz[linha, coluna] > 0) && (Matriz[linha, coluna] > MaiorValorZ))
                            {
                                MaiorValorZ = Matriz[linha, coluna]; ColunaPivo = coluna;
                            }
                        }
                    }


                    //MENOR VALOR DE B//
                    PrimeiraDivisao = Matriz[0, (Matriz.GetLength(1) - 1)] / Matriz[0, ColunaPivo];
                    for (linha = 0; linha < (Matriz.GetLength(0) - 1); linha++)
                    {
                        for (coluna = Matriz.GetLength(1) - 1; coluna < Matriz.GetLength(1); coluna++)
                        {
                            if (Matriz[linha, coluna] / Matriz[linha, ColunaPivo] < PrimeiraDivisao && Matriz[linha, coluna] / Matriz[linha, ColunaPivo] > 0)
                            {
                                Aux = Matriz[linha, coluna]; LinhaPivo = linha;
                            }
                        }
                    }


                    //PIVO//
                    Pivo = Matriz[LinhaPivo, ColunaPivo];


                    //DIVIDIR LINHA PELO PIVO//
                    for (linha = LinhaPivo; linha <= LinhaPivo; linha++)
                    {
                        for (coluna = 0; coluna < Matriz.GetLength(1); coluna++)
                        {
                            Matriz[linha, coluna] /= Pivo; MatrizAux[linha, coluna] = Matriz[linha, coluna];
                        }
                    }


                    //ZERAR COLUNA DO PIVO//
                    for (linha = 0; linha < Matriz.GetLength(0); linha++)
                    {
                        for (coluna = 0; coluna < Matriz.GetLength(1); coluna++)
                        {
                            if (linha != LinhaPivo)
                            {
                                MatrizAux[linha, coluna] = Matriz[LinhaPivo, coluna] * (-1 * Matriz[linha, ColunaPivo]) + Matriz[linha, coluna];
                            }
                        }
                    }


                    //PASSAR VALORES DA MATRIZAUX PARA MATRIZ//
                    for (linha = 0; linha < Matriz.GetLength(0); linha++)
                    {
                        for (coluna = 0; coluna < Matriz.GetLength(1); coluna++)
                        {
                            Matriz[linha, coluna] = MatrizAux[linha, coluna];
                        }
                    }


                    //TABELA RECEBE VALORES DA MATRIZ//
                    for (linha = 0; linha < Matriz.GetLength(0); linha++)
                    {
                        for (coluna = 0; coluna < Matriz.GetLength(1); coluna++)
                        {
                            Tabela.Rows[linha][coluna + 1] = (Matriz[linha, coluna].ToString());
                        }
                    }


                    //COLUNA ENTRA, LINHA SAI//
                    Tabela.Rows[LinhaPivo][0] = (Tabela.Columns[ColunaPivo + 1].ColumnName.ToString());


                    //VERIFICAR SE MATRIZ É ILIMITADA//
                    for (linha = 0; linha < Matriz.GetLength(0); linha++)
                    {
                        if (igual != true)
                        {
                            break;
                        }

                        for (coluna = 0; coluna < Matriz.GetLength(1); coluna++)
                        {
                            if (MatrizIlimitada[linha, coluna] != Matriz[linha, coluna])
                            {
                                igual = false;
                                break;
                            }
                            else { validar = 2; }
                        }
                    }


                    //MATRIZ ILIMITADA RECEBE PRIMEIRA INTERAÇÃO DE MATRIZ//
                    if (ilimitada == 0)
                    {
                        for (linha = 0; linha < Matriz.GetLength(0); linha++)
                        {
                            for (coluna = 0; coluna < Matriz.GetLength(1); coluna++)
                            {
                                MatrizIlimitada[linha, coluna] = Matriz[linha, coluna];
                            }
                        }
                        ilimitada = 1;
                    }
                    //FIM//
                }
            return (Matriz);
        }
        //-FIM MÉTODO INTERAÇÃO MINIMIZAÇÃO-//



        //-INICIO MÉTODO INTERAÇÃO MAXIMIZAÇÃO--//
        public float[,] IteracaoMax(float[,] Matriz)
        {
            int LinhaPivo = 0, ColunaPivo = 0, linha = 0, coluna = 0;
            float Pivo = 0, MenorValorZ = 0, Aux = 0, PrimeiraDivisao = 0;
            int cont = 0;
            bool igual = true;
            

            //MATRIZ RECEBE VALORES DA TABELA//
            for (linha = 0; linha < Matriz.GetLength(0); linha++)
            {
                for (coluna = 0; coluna < Matriz.GetLength(1); coluna++)
                {
                    Matriz[linha, coluna] = float.Parse(Tabela.Rows[linha][coluna + 1].ToString());
                }
            }


            //CRIAR MATRIZ AUXILIAR//
            float[,] MatrizAux = new float[VFolga + 1, VBasica + VFolga + 1];


            //PASSAR VALORES DA MATRIZ PARA MATRIZ AUXILIAR//
            for (linha = 0; linha < Matriz.GetLength(0); linha++)
            {
                for (coluna = 0; coluna < Matriz.GetLength(1); coluna++)
                {
                    MatrizAux[linha, coluna] = Matriz[linha, coluna];
                }
            }



            //VERIFICAR SE HÁ VALORES NEGATIVOS NA LINHA Z//
            for (coluna = 0; coluna < Matriz.GetLength(1); coluna++)
            {
                if (Matriz[(Matriz.GetLength(0) - 1), coluna] < 0) { cont = 1; }
            }

           

            if (cont != 1)
                MessageBox.Show("Não há iterações a serem feitas!", "Erro");


            if (cont == 1)
            {

                //MENOR VALOR DE Z//
                for (linha = (Matriz.GetLength(0) - 1); linha < Matriz.GetLength(0); linha++)
                {
                    for (coluna = 0; coluna < Matriz.GetLength(1)-1; coluna++)
                    {
                        if ((Matriz[linha, coluna] < 0) && (Matriz[linha, coluna] < MenorValorZ))
                        {
                            MenorValorZ = Matriz[linha, coluna]; ColunaPivo = coluna;
                        }
                    }
                }


                //MENOR VALOR DE B//
                PrimeiraDivisao = Matriz[0, (Matriz.GetLength(1) - 1)] / Matriz[0, ColunaPivo];
                for (linha = 0; linha < (Matriz.GetLength(0) - 1); linha++)
                {
                    for (coluna = Matriz.GetLength(1) - 1; coluna < Matriz.GetLength(1); coluna++)
                    {
                        if (Matriz[linha, coluna] / Matriz[linha, ColunaPivo] < PrimeiraDivisao && Matriz[linha, coluna] / Matriz[linha, ColunaPivo] > 0)
                        {
                            Aux = Matriz[linha, coluna]; LinhaPivo = linha;
                        }
                    }
                }


                //PIVO//
                Pivo = Matriz[LinhaPivo, ColunaPivo];


                //DIVIDIR LINHA PELO PIVO//
                for (linha = LinhaPivo; linha <= LinhaPivo; linha++)
                {
                    for (coluna = 0; coluna < Matriz.GetLength(1); coluna++)
                    {
                        Matriz[linha, coluna] /= Pivo; MatrizAux[linha, coluna] = Matriz[linha, coluna];
                    }
                }


                //ZERAR COLUNA DO PIVO//
                for (linha = 0; linha < Matriz.GetLength(0); linha++)
                {
                    for (coluna = 0; coluna < Matriz.GetLength(1); coluna++)
                    {
                        if (linha != LinhaPivo)
                        {
                            MatrizAux[linha, coluna] = Matriz[LinhaPivo, coluna] * (-1 * Matriz[linha, ColunaPivo]) + Matriz[linha, coluna];
                        }
                    }
                }


                //PASSAR VALORES DA MATRIZAUX PARA MATRIZ//
                for (linha = 0; linha < Matriz.GetLength(0); linha++)
                {
                    for (coluna = 0; coluna < Matriz.GetLength(1); coluna++)
                    {
                        Matriz[linha, coluna] = MatrizAux[linha, coluna];
                    }
                }


                //TABELA RECEBE VALORES DA MATRIZ//
                for (linha = 0; linha < Matriz.GetLength(0); linha++)
                {
                    for (coluna = 0; coluna < Matriz.GetLength(1); coluna++)
                    {
                        Tabela.Rows[linha][coluna + 1] = (Matriz[linha, coluna].ToString());
                    }
                }


                //COLUNA ENTRA, LINHA SAI//
                Tabela.Rows[LinhaPivo][0] = (Tabela.Columns[ColunaPivo + 1].ColumnName.ToString());


                //VERIFICAR SE MATRIZ É ILIMITADA//
                for (linha = 0; linha < Matriz.GetLength(0); linha++)
                {
                    if (igual != true)
                    {
                        break;
                    }

                    for (coluna = 0; coluna < Matriz.GetLength(1); coluna++)
                    {
                        if (MatrizIlimitada[linha, coluna] != Matriz[linha, coluna])
                        {
                            igual = false;
                            break;
                        }
                        else { validar = 2; }
                    }
                }


                //MATRIZ ILIMITADA RECEBE PRIMEIRA INTERAÇÃO DE MATRIZ//
                if (ilimitada == 0)
                {
                    for (linha = 0; linha < Matriz.GetLength(0); linha++)
                    {
                        for (coluna = 0; coluna < Matriz.GetLength(1); coluna++)
                        {
                            MatrizIlimitada[linha, coluna] = Matriz[linha, coluna];
                        }
                    }
                    ilimitada = 1;
                }
                //FIM//

            }
            return (Matriz);
        }
        //-FIM MÉTODO INTERAÇÃO MAXIMIZAÇÃO-//

        //-INICIO GERAR RESULTADO-//
        private void btResultado_Click(object sender, EventArgs e)
        {
            lstResultado.Items.Clear();
            if (Tabela.Rows.Count > 0)
            {
                for (int linha = 0; linha < Tabela.Rows.Count; linha++)
                {
                    lstResultado.Items.Add(Tabela.Rows[linha][0].ToString() + " = " + float.Parse(Tabela.Rows[linha][VFolga + VBasica + 1].ToString()).ToString("N1"));
                }
            }
            else
                MessageBox.Show("Crie uma Matriz!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //-FIM GERAR RESULTADO-//
    }
}