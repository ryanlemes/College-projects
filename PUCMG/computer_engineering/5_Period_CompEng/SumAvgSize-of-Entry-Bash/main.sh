#programador: Ryan Lemes Bezerra Matrícula: 520402
#nome do programa: g1.sh
#data : 29/08/2018
#descricao: Ler pelo teclado uma seqüência de números inteiros positivos de tamanho indeterminado
# (fornecidos pelo usuário via teclado) e imprima a soma destes números (SOMA), a média (MEDIA)
# e o tamanho da seqüência (N) . Para indicar o fim da seqüência use como “FLAG” (terminador)
# um número negativo (p. ex. –1).
#entrada(s): a sequencia de inteiros
#saida(s): soma, media e tamanho das entradas
echo "SO Lab"
echo "Ryan Lemes Bezerra - matricula: 520402"
echo "Program G1 - Sequência"
entrada=1
soma=0
media=0
count=0

while((entrada>0))
do
   echo "Digite uma entrada"
   read entrada
   if ((entrada>0));
   then
       ((count=count+1))
       ((soma=soma+entrada))
   fi
done

echo "Finalizado"
echo "Soma $soma"

((media=soma / count))
echo "Media $media"
echo "Quantidade $count"
