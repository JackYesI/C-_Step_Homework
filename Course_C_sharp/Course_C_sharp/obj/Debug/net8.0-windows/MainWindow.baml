   M S B A M L   `   `   `  ����I  ECourse_C_sharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Course_C_sharpCourse_C_sharp  5   	       Course_C_sharp.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Course_C_sharp     5   	     � Title$  
FileSystem��5   	   $	��472��6   $	��800��6)    � 
ResizeMode$ NoResize=�5	   	   .��5      � .+�5   
   �� -   5        $��Reset��5         ResetButtonStyle#��[  6!   $
��Left=�6K   $��
10,373,0,0q�6f   $	��Top=�6z    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��41��6�   $��60��6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ -0.205Q�6&   T� 5      5      5      �� 5   
   -   5         ��Name$ PathTextBox��5        CustomTextBoxStyle#��[ 6'   $��Center=�6S   $��0,10,0,0q�6p    �� TextWrapping$
 Wrap=�6�   $��for statr click on buttom��6�   $	��Top=�6�   $	��762��6�   $��33��6�   6�   �� 5   
   -   5        $��FileListView��5      $��10,117,10,65q�6I   ��6'   �� *	FileItems+ �� View 5      �� 5      .P�5      �� $
��Name��6%    �� Width$	 200��6Y    �� DisplayMemberBinding 63   �� *Name+6Y   �� 5      $��Is Directory��6%   $	 100��6h    6;   �� *IsDirectory+6h   5      5       �� 5!   
   -   5        $ FileChanger��5!      #��[ 6'   $
��Left=�6S   $��	10,89,0,0q�6n   $
 Wrap=�6�   $��i'm check your file, dude��6�   $	��Top=�6�   $	��195��6�   �� 5"   
   -   5        $��create��5"        ButtonStyle#��[ 6"   $
��Left=�6G   $��
233,62,0,0q�6b   $	��Top=�6v   $ 
0.55,0.112&�6�   �� 5#   
   -   5        $��delete��5#      #��[ 6"   $
��Left=�6G   $��
316,64,0,0q�6b   $	��Top=�6v   6�   �� 5$   
   -   5        $
��edit��5$      #��[ 6    $
��Left=�6E   $��
381,92,0,0q�6`   $	��Top=�6t   6�   �� 5%   
   -   5        $
��show��5%      #��[ 6    $
��Left=�6E   $��
417,92,0,0q�6`   $	��Top=�6t   6�   �� 5&   
   -	   5        $ editBox��5&      #��[ 6#   $
��Left=�6O   $��
76,373,0,0q�6j   $
 Wrap=�6~   $	��...��6�   $	��Top=�6�   $	��699��6�   $��50��6�   �� 5'   
   -
   5        $��create file��5'      #��[ 6'   $
��Left=�6L   $��
216,92,0,0q�6g   $	��Top=�6{   $��25��6�   $��82��6�   6�   �� 5(   
   -   5        $��delete file��5(      #��[ 6'   $
��Left=�6L   $��
303,92,0,0q�6g   $	��Top=�6{   6�   �� 5)   
   -   5        $ destination��5)      #��[ 6'   $
��Left=�6S   $��
527,89,0,0q�6n   $
 Wrap=�6�   $��Box for destination��6�   $	��Top=�6�   $	��248��6�   �� 5*   
   -   5        $
��Move��5*      #��[ 6    $
��Left=�6E   $��
463,92,0,0q�6`   $	��Top=�6t   6�   �� 5+   
   -   5        $
��info��5+      #��[ 6    $
��Left=�6E   $��	10,64,0,0q�6`   $	��Top=�6s   6�   ��5,   
   �� 5-      	 �� Color$	 #CCE5FF��6   5/      51      