   M S B A M L   `   `   `  ����G  CWpfFinalDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfFinalDemoWpfFinalDemo  5   	       WpfFinalDemo.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:WpfFinalDemo     5   	   -   5          �Name$  
mainWindow��5   	    � Title$) #Украшения | Главная��6   $	��450��69   $	��800��6F    � Icon$ Resources/icon.ico��6R   .��5	      �  � RowDefinitions 5
   
   �� 5      $��50 �6   6*   �� 5      6   .+�5   
   �� $��0��6   ���	#FFFFCC9964   �� 5   
   $��0��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� $��40��6   $��40��6    $��10,0,0,0q�6+   $��Resources/logo.png��6=   6[   �� 5      $#��ООО «Украшение»��6   $��Center=�6/   $��10,0,0,0q�6J   6^   5      �� 5   
   -   5         ��Name$ 
backButton��5      $��
Назад��6%   $��0��65   $��Right=�6B   $��70��6^   $��20��6i   $��0,0,10,0q�6u   6�    � 5   
   -   5          �Name$ 	mainFrame��5      $��1��6#     � NavigationUIVisibility$ Hidden=�60   6r   5      5      