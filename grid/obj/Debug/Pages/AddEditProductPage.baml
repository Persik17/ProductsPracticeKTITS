   M S B A M L   `   `   `  ����?  ;grid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:grid.Pages
grid.Pages  5      #    grid.Pages.AddEditProductPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:grid.Pages     5        N� Title$  AddEditProductPage��5	      .��5      �� .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��5,0,5,5q�6   .+�5      �� $��Имя��6   �� 5      -   5         ��Name$ NameProductTextBox��5   /   ���#CEFFF9$	��250��6a   ��6K   �� *Name+6a   5      �� 5      $��5,0,5,5q�6   .+�5      �� $��Артикул��6   �� 5      -   5        $ ArticleProductTextBox��5   /   ���#CEFFF9$	��150��6m   ��6N   �� *ArticleNumber+6m   5      �� 5      $��5,0,5,5q�6   .+�5      �� $��Тип��6   �� 5      -   5         ��Name$ TypeProductComboBox��5   0   ���#CEFFF9 �� DisplayMemberPath$
 Name��6M    �� SelectedValue$ Id��6f   $	��250��6�    �� SelectedItem 6y   �� *ProductType+6�   5      5      �� 5   
   $ 
Horizontal=�6   .+�5      �� $��5,0,5,5q�6   $
��Left=�6*   .+�5      �� $��Описание��6   �� 5      -   5        $ DescriptionProductTextBox��5   /   ���#CEFFF9$��60��6o   $	��400��6{    �� TextWrapping$ WrapWithOverflow=�6�   ��6R   �� *Description+6�   5      �� 5      $ 
Horizontal=�6   $	��300��62   .+�5       �� $ 
Horizontal=�6   .+�5!      �� $��Фото��6   �� 5"      
���   �$��1q�61   ._�5#      �� -   5         ��Name$ ImageBox��5#   N   $	��100��6B   ��6    �� *Image1.Source+6N   5$      5%      �� 5&      $��Bottom=�6   .+�5'      �� -   5        	 ��Name$	 AddImageBtn��5'   <   $	��150��6   $��Добавить��6)   6Q   5(      5)      5*      �� 5+   
   $��5,0,5,5q�6   .+�5,      �� $%��Минимальная цена��6   �� 5-      -   5        $ MinCostProductTextBox��5-   +   ���#CEFFF9��6J   �� *MinCostForAgent+5.      �� 5/   
   $ 
Horizontal=�6   $	��200��6.   .+�50      �� $	��170��6   $	��400��6&   .+�51      �� $ 
Horizontal=�6   .+�52      �� $��5,0,5,5q�6!   .+�53      �� $<��6Кол-во людей для производства��6    �� 54      -   5        $, &CountPeopleForProductionProductTextBox��54   7   ���#CEFFF9��6g   �� *CountPeopleForProduction+6�   55      �� 56      $��5,0,5,5q�6!   .+�57      �� $��Номер цеха��6    �� 58      -	   5        $ WorkshopProductTextBox��58   7   ���#CEFFF9��6W   �� *
Workshop+59      5:      5;      �� 5<      $	��200��6   .+�5=      �� $)��#Материалы продукта��6   �� 5>      $	��300��6   .+�5?      &   System.Windows.Controls.DataGrid  ���#CEFFF9$	��300��64   $	��115��6@   
   AutoGenerateColumns
 .     
IsReadOnly . ��6i   �� *
Production+   Columns 5@      0  *System.Windows.Controls.DataGridTextColumn  5A      ,  &System.Windows.Controls.DataGridColumn   Header$ Материалы��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6D   �� *Material.Name+  5B      $ Материалы��61    6D   �� *Count+5D      5E      �� 5F      $ 
Horizontal=�6   .+�5G      �� -
   5        $	 AddMaterialBtn��5G      $	��150��65   $��Добавить��6A   6T   5H      5I      5J      �� 5K   
   $ 
Horizontal=�6   .+�5L      �� -   5        $	 SaveBtn��5L      $��Сохранить��6&   $	��150��6:   $��5,0,5,5q�6F   6W   �� 5M      -   5        $	 BackBtn��5M      $��
Назад��6&   $	��150��66   $��5,0,5,5q�6B   6S   5N      5O      5P      