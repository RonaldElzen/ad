   M S B A M L   `   `   `  ���� G  CEindopdracht, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:EindopdrachtEindopdracht      Eindopdracht.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:Eindopdracht       � Title$  
MainWindow��$	��436��$��649.833��.��� $	��394��$	��Top=�$��8,-6,2,0q� � RowDefinitions �� $
��170* ��� $	��27* � � ColumnDefinitions �� $
��242* ��� $
��153* ��� $	��59* ��� $	��42* ��� $
��137* �.+��� -    ��Name$ 
tabControl��$
��Left=�$��0,10,0,0q�$	��622��$��5��$��2��.@��� -   $ tabControl1��$
��Left=�$	��364��$	��Top=�$	��612��.@��� $��TabItem��$
��-2,0q�.��� ���#FFF$��
0,2,-12,10q� �� $	��61* ��� $	��15* �.+��� -    ��Name$ 
textBoxOld��$
��Left=�$	��208��$��	11,25,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��219���� -    ��Name$ 	btnBubble��$��Bubble��$
��Left=�$��142,288,0,0q�$	��Top=�$	��112��$��20�� J� RenderTransformOrigin$ 
0.524,1.75&��� -   $ textBoxArraySize��$
��Left=�$��22��$��248,242,0,0q�$
 Wrap=�$	��Top=�$	��160���� -    ��Name$ label��$��Size of array��$
��Left=�$��142,238,0,0q�$	��Top=�$ 0.5,0.5&�$��88��$��26���� -   $ btnInsertion��$��	Insertion��$
��Left=�$��
11,288,0,0q�$	��Top=�$	��112��$��19���� -   $ btnSmart��$��Smart bubblesort��$
��Left=�$��272,288,0,0q�$	��Top=�$	��112��$��19���� -	   $ 
textBoxNew��$
��Left=�$	��208��$��
248,25,0,0q�$
 Wrap=�$	��Top=�$	��220���� -
   $ label1��$��Sorting time:��$
��Left=�$��477,103,0,0q�$	��Top=�$��92��$��25��$��2���� -   $ 	labelTime��$��Label��$
��Left=�$��483,133,0,0q�$	��Top=�$��89��$��25��$��2���� -   $ labelSorted��$��Sorted:��$
��Left=�$��	248,0,0,0q�$	��Top=�$��57��$��25��$ 0.518,-0.46&��� -   $ labelUnsorted��$��	unsorted:��$
��Left=�$��10,0,0,0q�$	��Top=�$��71��$��25��$ 
0.514,-0.4&��� -   $ btnClear��$��Clear��$
��Left=�$��483,214,0,0q�$	��Top=�$��89��$��19��$��2���� $��TabItem��$
��-2,0q�.��� ���#FFF �� $	��25* ��� $	��43* ��� $	��76* ��� $
��452* �.+��� -   $ textBoxSearch��$
��Left=�$��23��$��
10,249,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��120��$��2��$��2���� -   $ btnSearchBinary��$��Binary Search��$
��Left=�$��
10,288,0,0q�$	��Top=�$��74��$��2��$��2���� -   $ 
textBoxArr��$
��Left=�$	��208��$��0,36,0,0q�$
 Wrap=�$	��Top=�$	��220��$��2��$��2���� -   $ btnSearchSequential��$��Sequential Search��$
��Left=�$��
10,313,0,3q�$��74��$��2��$��2���� $��TabItem��$��	-3,0,-1,0q�$��22��$	��Top=�.��� ���#FFF �� $	��25* ��� $	��43* ��� $	��68* ��� $
��461* �.+��� -   $ textBoxQueue��$��3��$
��Left=�$��22��$��49.5,45,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��120���� -   $ label2��$��Label��$��2��$
��Left=�$��	52,45,0,0q�$	��Top=�$��2���� -   $ textBoxShowQueue��$��3��$
��Left=�$	��281��$��212.5,45,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��238���� -   $ buttonEnqueue��$��Enqueue��$��3��$
��Left=�$��2.5,170,0,0q�$	��Top=�$��74���� -   $ buttonDequeue��$��Dequeue��$��3��$
��Left=�$��95.5,170,0,0q�$	��Top=�$��74���� $��TabItem��$��0,0,-4,0q�.��� ���#FFF$��10,-3,14,18q� �� $	��25* ��� $	��43* ��� $	��68* ��� $
��461* �.+��� -   $ textBoxStack��$��3��$
��Left=�$��22��$��49.5,45,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��120���� -   $ label3��$��Label��$��2��$
��Left=�$��	52,45,0,0q�$	��Top=�$��2���� -   $ textBoxShowStack��$��3��$
��Left=�$	��232��$��
194,45,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��238���� -   $ 
buttonPush��$
��Push��$��3��$
��Left=�$��2.5,170,0,0q�$	��Top=�$��74���� -   $ 	buttonPop��$	��POP��$��3��$
��Left=�$��95.5,170,0,0q�$	��Top=�$��74��