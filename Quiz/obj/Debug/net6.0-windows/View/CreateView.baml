   M S B A M L   `   `   `  ����?  ;Quiz, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Quiz.View	Quiz.View  5      /clr-namespace:Quiz.ViewModelQuiz.ViewModel  6-       Quiz.View.CreateView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Quiz.View     5      2	viewmodelclr-namespace:Quiz.ViewModel     6-   .��5
      � ���#393646  � ColumnDefinitions  5   
   �� 5      $��1* �6   �� 5      $��3* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� $��20(�6   $��30q�6   $��Wróć��6+   $��3q�6:   
���   ����#9D9788��6w   �� *NavigateMenuCommand+�� 5   
   $��25(�6   $
��20pxq�6   $��Stwórz nowy Quiz��6-   $��1��6H   $��1��6X   $��3q�6e   
���   ����#FFD659��6�   �� *NavigateToCreateNameCommand+�� 5    
   $��1��6   $��2��6    $	��Top=�6-   $��Center=�6E   
�������$��20(�5!      $9��3lub wybierz Quiz do zedytowania z poniższej listy:��6   $��0,73,0,0q�6Y   �� 5"   
   $��20(�6   $��20q�6    $��1��6,   $��3��6<   $��2��6I   $��3q�6Z   
���   ����#F4EEE0$��Center=�6�   ��6�   �� *Items+ �� SelectedItem 6�   �� *SelectedItem+�� 5#   
   $��20(�6   $
��30pxq�6   $��1��6U   $��5��6e   $��3q�6r   
���   ����#FF5959��6-   �� *RemoveButtonContent+��6�   �� *EreaseTheQuestions+5%      5&      