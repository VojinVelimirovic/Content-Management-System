   M S B A M L   `   `   `  ����T  PContent Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Content_Management_SystemContent_Management_System  5      W SNotification.Wpf, Version=8.0.0.0, Culture=neutral, PublicKeyToken=1acac493089262b5_Aclr-namespace:Notification.Wpf.Controls;assembly=Notification.WpfNotification.Wpf.Controls 5	      +    %Content_Management_System.TableWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome5.Net, Version=2.1.11.0, Culture=neutral, PublicKeyToken=9cfaf01297a008f8/fa5%http://schemas.fontawesome.com/icons/  5      3local'clr-namespace:Content_Management_System  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      UnotificationsAclr-namespace:Notification.Wpf.Controls;assembly=Notification.Wpf  5	      -   5          � Title$  Table��5
       � AllowsTransparency . 
������  � SizeToContent$ WidthAndHeight=�5       � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�5      .��5      �� ���#333333$��10q�6#   ._�5   
   �� $
��1280��6   $	��768��6   .+�5      F�    PathBackgroundStyle#��[  6   ��5      B� 5      ��5      E�  E� 
StartPoint$	 0,0&�6)   ��5   &   @� �� 5   *    �� Point$ 1280,0&�66   �� 5   *   $ 1280,768&�66   �� 5   *   $ 0,768&�66   �� 5   *   $	 0,0&�66   5    '   5"      5$      5&      F� 5'        PathShadowEffectStyle#��[ 6   ��5(      B� 5)      ��5+      E� $	 0,0&�6)   ��5-   &   �� $ 1280,0&�62   �� 5.   &   $ 1280,768&�62   �� 5/   &   $ 0,768&�62   �� 50   &   $	 0,0&�62   52      54      56      ]� 57      $
��1280��58      $��0q�59      ��. .+�5;      �� $	��300��5<      $��0q�5=      $
��Left=�5>       J� Opacity$	 0.7Q�5?      $��Images/TopLeftCorner.png��5@      �� 5A      $	��300��5B      $��0q�5C      $��Right=�5D      $	 0.7Q�5E      $��Images/TopRightCorner.png��5F      � 5G      $	��Top=�6   .+�5H      �� $��40��5I      $��25q�5J      $��Center=�5K      $	��Top=�5L      $	 0.8Q�5M      $��Images/CoatOfArms2.png��5N      5O      5P      � 5Q      $��130,70q�6    � ColumnDefinitions 5R      �� 5S      $��* �6'   �� 5T      $��* �6'   �� 5U      $��* �6'   	 � RowDefinitions	 5W      �� 5X      $��* �6$   �� 5Y      $��6* �6$   .+�5[      �� -   5        $��	AddButton��5\      $��0��5]      $��0��5^      $	��260��5_      $��70��5`      $
��0,30q�5a      $��6q�5b        ButtonStyle#��[ 5d      
 � ToolTip$
 Add an item to the table��5e      .��5f      ��  �� Orientation$ 
Horizontal=�6!   .+�5g        FontAwesome5.SvgAwesome  $��30��5h      $��0,0,8,0q�5i      $��Center=�5j      $��Center=�5k         
Foreground
 �����   Icon$ 
Solid_Plus=�5m      �� 5n      $��27(�6$   Add67   5o      5p      �� 5q      -   5        $��RemoveButton��5r      $��0��5s      $��1��5t      $	��260��5u      $��70��5v      $
��0,30q�5w      $��6q�5x      #��[ 5z      $#
 Remove item(s) from the table��5{      .��5|      �� $ 
Horizontal=�6!   .+�5}        $��30��5~      $��0,0,8,0q�5      $��Center=�5�      $��Center=�5�      
 �����$ Solid_Trash=�5�      �� 5�      $��27(�6$   Remove6:   5�      5�      �� 5�      -   5        $��LogOutButton��5�      $��0��5�      $��2��5�      $	��260��5�      $��70��5�      $
��0,30q�5�      $��6q�5�      #��[ 5�      $
 Log out of your account��5�      .��5�      �� $ 
Horizontal=�6!   .+�5�        $��30��5�      $��0,2,8,0q�5�      $��Center=�5�      $��Center=�5�      
 �����$ Solid_SignOutAlt=�5�      �� 5�      $��27(�6$   	Log Out6;   5�      5�      &   System.Windows.Controls.DataGrid  5�      -   5        $��FiguresDataGrid��5�      $��1��5�      $��3��5�      $
��1020��5�      $	��498��5�         AutoGenerateColumns .  ���#333333$��2q�5�         CanUserAddRows .     CanUserReorderColumns .     CanUserResizeColumns .     CanUserResizeRows .     HeadersVisibility$ Column=�5�         
IsReadOnly . ��. $
��Auto=�5�      $
��Auto=�5�        DataGridShadowEffectStyle#��[ 5�      ��5�      �� *	figures+ � 	Resources 5�      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value �� 
TargetType ]� Thumb��%%  '        '��     �� 5�      "  6    .�5�      ��  � ��$ Center=�6D   �� 5�       � ��
 ���� 6;   �� 5�       � ��
 �����6;   �� 5�       � ��$ Imprint MT Shadow)�6;   �� 5�       � ��$ 35��67   �� 5�       � ��$ 24(�69   5�      �� 5�      " ��6    .�5�      ��  � ��
 ���� 6;   �� 5�       � �� 5�   "   �� 5�   &   " ��66   .R�5�   *   ]� ��.  5�   .   n� 5�   2   ���#3f4f22
������ $��0q�5�   5   5�   +   5�   '   5�      5�      5�         RowStyle 5�      �� 5�      )  #System.Windows.Controls.DataGridRow"  6    .�5�      ��  � ��$ 0,1,0,0q�6@   �� 5�       � �� �#3333336<   �� 5�       � ��
 ���� 6;   �� 5�       � ��$ Imprint MT Shadow)�6;   �� 5�       � ��$ 22(�69   �� 5�       � ��
 �����6;   �� 5�       � |� .  6:   �� 5�       �@��TextAlignment$ Center=�6H   �� 5�       � ��$ Center=�6L   5�         Columns 5�      4  .System.Windows.Controls.DataGridTemplateColumn  5�      -   5        CheckBoxColumn��,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5�         Header$  ��5�         CellTemplate 5�      �� 5�   "   .R�5�   &   �� $��Center=�5�   )   $��Center=�5�   )     � Cursor$
  Hand��5�   )   $
 Check to remove��5�   )   ! d� 	IsChecked! 5�   )   �� *	IsChecked+" �� UpdateSourceTrigger$" PropertyChanged=�5�   )   5�   #   5�        5�      $ 2* 61   $
 Name��6<    5�      �� 5�   "   .R�5�   &   �� $��NameTextBlock��5�   )   -   5        $��Center=�5�   )   $
  Hand��5�   )   # �� TextAlignment$# Center=�5�   )   $��	Underline{�5�   )   ��5�   )   �� *Name+5�   )   5�   #   5�        5�      $ 2* 61   $ Reign��6<    5�      �� 5�   "   .R�5�   &   �� $��Center=�5�   )   $# Center=�5�   )   ��5�   )   �� *ReignFormat+5�   )   5�   #   5       5     $ 2* 61   $ Portrait��6<    5     �� 5  "   .R�5  &   �� $	��110��5  )   $	��120��5  )   ��5  )   �� *Image+5	  #   5       5     $ 2* 61   $ 
Date Added��6<    5     �� 5  "   .R�5  &   �� $��Center=�5  )   $# Center=�5  )   ��5  )   �� *	DateAdded+$ �� StringFormat$$ {0:d}��5  )   5  #   5     5     5     0  *Notification.Wpf.Controls.NotificationArea  5     -   5        %  Name$!% TableWindowNotificationArea��5     & K� ZIndex$
& 1000��5     '   MaxItems$' 3��5     (   Position$( BottomRight=�5     5     5     5      