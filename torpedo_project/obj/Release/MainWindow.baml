   M S B A M L   `   `   `  ����   torpedo_project     torpedo_project.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     � Title$  Torpedo��$	��500��$	��800��$��Center=�$��Center=�����  �� EndPoint$ 0.5,1&� � MappingMode$ RelativeToBoundingBox=� �� 
StartPoint$ 0.5,0&�.���  � Color$ 
Aquamarine�� � Offset$ 1Q�� $ Lightseagreen�� � 	Resources    	ShipFront  ShipMid  ShipBack  LeftShipFront  LeftShipMid  LeftShipBack 
 NotHit  ShipHitFront  
ShipHitMid 	 ShipHitBack 
 ShipHitLeftFront  ShipHitLeftMid  ShipHitLeftBack��%D  &	       &	 P    &	 �    &	    &	 k   &	 �   &	 /   &	 �   &	 �   &		 1   &	
 �   &	 �   &	 Z   �� $��Resources/frontship.png��$��-1,-2q�$��UniformToFill=�$��Center=��� $��Resources/midship.png��$��UniformToFill=�$��Center=�$��Center=�$
��0,-2q��� $��Resources/backship.png��$��UniformToFill=�$��Center=�$��Center=�$
��0,-2q��� $!��Resources/leftshipfront.png��$��Center=�$��Center=�$��
0,-2,-5,-2q�$��UniformToFill=��� $��Resources/leftmidship.png��$��Center=�$��Center=�$��-5,-2q�$��UniformToFill=��� $ ��Resources/leftshipback.png��$��Center=�$��Center=�$��
-5,-2,0,-2q�$��UniformToFill=��� $��Resources/NotHit.png��$��
-4,-2,0,-2q�$��UniformToFill=�$��Center=��� $ ��Resources/ShipHitFront.png��$��-1,-2q�$��UniformToFill=�$��Center=��� $��Resources/ShipHitMid.png��$��UniformToFill=�$��Center=�$��Center=�$
��0,-2q��� $��Resources/ShipHitBack.png��$��UniformToFill=�$��Center=�$��Center=�$
��0,-2q��� $$��Resources/ShipHitLeftFront.png��$��Center=�$��Center=�$��
0,-2,-5,-2q�$��UniformToFill=��� $"��Resources/ShipHitLeftMid.png��$��Center=�$��Center=�$��-5,-2q�$��UniformToFill=��� $#��Resources/ShipHitLeftBack.png��$��Center=�$��Center=�$��
-5,-2,0,-2q�$��UniformToFill=�.���� -    ��Name$ game_window��.+��� $��Round:��$
��Left=�$	��Top=�$��20,0,0,0q��� -    ��Name$ number_of_rounds��$��0��$
��Left=�$	��Top=�$��75,0,0,0q��� $��Player name:��$
��Left=�$	��Top=�$��	308,0,0,0q��� -   $ turn_indicator��$��place your boats!��$��Center=�$��Center=�	 �� Left$		 349��

 �� Top$	
 129���� -   $ player_name_test_label��$��namehere��$
��Left=�$��	392,0,0,0q�$	��Top=�� -    �Name$ PlayerShipTable��$	 10��$
 54��$	��288��$	��280�� � ColumnDefinitions �� $	��13* ��� $	��13* ��� $
��118* ��� $��0* � � RowDefinitions �� $
��150* ��� $	��24* ��� $	��23* ��� $	��26* ��� $	��12* ��� $	��45* �.+��� -    ��Name$ no��$
��Left=�$��25��$	��Top=�$��25���� -    ��Name$ A��$��A��$
��Left=�$��25��$	��Top=�$��25��$��1���� -	   $ B��$��B��$
��Left=�$��25��$	��Top=�$��25��$��2���� -
   $ C��$��C��$
��Left=�$��25��$	��Top=�$��25��$��25,0,0,0q�$��2���� -   $ D��$��D��$
��Left=�$��25��$	��Top=�$��25��$��50,0,0,0q�$��2���� -   $ E��$��E��$
��Left=�$��25��$	��Top=�$��25��$��75,0,0,0q�$��2���� -   $ F��$��F��$
��Left=�$��25��$	��Top=�$��25��$��	100,0,0,0q�$��2���� -   $ G��$��G��$
��Left=�$��25��$	��Top=�$��25��$��	125,0,0,0q�$��2���� -   $ H��$��H��$
��Left=�$��25��$	��Top=�$��25��$��	150,0,0,0q�$��2���� -   $ I��$��I��$
��Left=�$��25��$	��Top=�$��25��$��	175,0,0,0q�$��2���� -   $ J��$��J��$
��Left=�$��25��$	��Top=�$��25��$��	200,0,0,0q�$��2���� -   $	 no1��$��1��$
��Left=�$��25��$	��Top=�$��25��$��0,25,0,0q��� -   $ A1��$
��Left=�$��25��$	��Top=�$��25��$��0,25,0,0q�$��1���� -   $ B1��$
��Left=�$��25��$	��Top=�$��25��$��0,25,0,0q�$��2���� -   $ C1��$
��Left=�$��25��$	��Top=�$��25��$��	25,25,0,0q�$��2���� -   $ D1��$
��Left=�$��25��$	��Top=�$��25��$��	50,25,0,0q�$��2���� -   $ E1��$
��Left=�$��25��$	��Top=�$��25��$��	75,25,0,0q�$��2���� -   $ F1��$
��Left=�$��25��$	��Top=�$��25��$��
100,25,0,0q�$��2���� -   $ G1��$
��Left=�$��25��$	��Top=�$��25��$��
125,25,0,0q�$��2���� -   $ H1��$
��Left=�$��25��$	��Top=�$��25��$��
150,25,0,0q�$��2���� -   $ I1��$
��Left=�$��25��$	��Top=�$��25��$��
175,25,0,0q�$��2���� -   $ J1��$
��Left=�$��25��$	��Top=�$��25��$��
200,25,0,0q�$��2���� -   $	 no2��$��2��$
��Left=�$��25��$	��Top=�$��25��$��0,50,0,0q��� -   $ A2��$
��Left=�$��25��$	��Top=�$��25��$��0,50,0,0q�$��1���� -   $ B2��$
��Left=�$��25��$	��Top=�$��25��$��0,50,0,0q�$��2���� -    $ C2��$
��Left=�$��25��$	��Top=�$��25��$��	25,50,0,0q�$��2���� -!   $ D2��$
��Left=�$��25��$	��Top=�$��25��$��	50,50,0,0q�$��2���� -"   $ E2��$
��Left=�$��25��$	��Top=�$��25��$��	75,50,0,0q�$��2���� -#   $ F2��$
��Left=�$��25��$	��Top=�$��25��$��
100,50,0,0q�$��2���� -$   $ G2��$
��Left=�$��25��$	��Top=�$��25��$��
125,50,0,0q�$��2���� -%   $ H2��$
��Left=�$��25��$	��Top=�$��25��$��
150,50,0,0q�$��2���� -&   $ I2��$
��Left=�$��25��$	��Top=�$��25��$��
175,50,0,0q�$��2���� -'   $ J2��$
��Left=�$��25��$	��Top=�$��25��$��
200,50,0,0q�$��2���� -(   $	 no3��$��3��$
��Left=�$��25��$	��Top=�$��25��$��0,75,0,0q��� -)   $ A3��$
��Left=�$��25��$	��Top=�$��25��$��0,75,0,0q�$��1���� -*   $ B3��$
��Left=�$��25��$	��Top=�$��25��$��0,75,0,0q�$��2���� -+   $ C3��$
��Left=�$��25��$	��Top=�$��25��$��	25,75,0,0q�$��2���� -,   $ D3��$
��Left=�$��25��$	��Top=�$��25��$��	50,75,0,0q�$��2���� --   $ E3��$
��Left=�$��25��$	��Top=�$��25��$��	75,75,0,0q�$��2���� -.   $ F3��$
��Left=�$��25��$	��Top=�$��25��$��
100,75,0,0q�$��2���� -/   $ G3��$
��Left=�$��25��$	��Top=�$��25��$��
125,75,0,0q�$��2���� -0   $ H3��$
��Left=�$��25��$	��Top=�$��25��$��
150,75,0,0q�$��2���� -1   $ I3��$
��Left=�$��25��$	��Top=�$��25��$��
175,75,0,0q�$��2���� -2   $ J3��$
��Left=�$��25��$	��Top=�$��25��$��
200,75,0,0q�$��2���� -3   $	 no4��$��4��$
��Left=�$��25��$	��Top=�$��25��$��	0,100,0,0q��� -4   $ A4��$
��Left=�$��25��$	��Top=�$��25��$��	0,100,0,0q�$��1���� -5   $ B4��$
��Left=�$��25��$	��Top=�$��25��$��	0,100,0,0q�$��2���� -6   $ C4��$
��Left=�$��25��$	��Top=�$��25��$��
25,100,0,0q�$��2���� -7   $ D4��$
��Left=�$��25��$	��Top=�$��25��$��
50,100,0,0q�$��2���� -8   $ E4��$
��Left=�$��25��$	��Top=�$��25��$��
75,100,0,0q�$��2���� -9   $ F4��$
��Left=�$��25��$	��Top=�$��25��$��100,100,0,0q�$��2���� -:   $ G4��$
��Left=�$��25��$	��Top=�$��25��$��125,100,0,0q�$��2���� -;   $ H4��$
��Left=�$��25��$	��Top=�$��25��$��150,100,0,0q�$��2���� -<   $ I4��$
��Left=�$��25��$	��Top=�$��25��$��175,100,0,0q�$��2���� -=   $ J4��$
��Left=�$��25��$	��Top=�$��25��$��200,100,0,0q�$��2���� ->   $	 no5��$��5��$
��Left=�$��25��$	��Top=�$��25��$��	0,125,0,0q��� -?   $ A5��$
��Left=�$��25��$	��Top=�$��25��$��	0,125,0,0q�$��1���� -@   $ B5��$
��Left=�$��25��$	��Top=�$��25��$��	0,125,0,0q�$��2���� -A   $ C5��$
��Left=�$��25��$	��Top=�$��25��$��
25,125,0,0q�$��2���� -B   $ D5��$
��Left=�$��25��$	��Top=�$��25��$��
50,125,0,0q�$��2���� -C   $ E5��$
��Left=�$��25��$	��Top=�$��25��$��
75,125,0,0q�$��2���� -D   $ F5��$
��Left=�$��25��$	��Top=�$��25��$��100,125,0,0q�$��2���� -E   $ G5��$
��Left=�$��25��$	��Top=�$��25��$��125,125,0,0q�$��2���� -F   $ H5��$
��Left=�$��25��$	��Top=�$��25��$��150,125,0,0q�$��2���� -G   $ I5��$
��Left=�$��25��$	��Top=�$��25��$��175,125,0,0q�$��2���� -H   $ J5��$
��Left=�$��25��$	��Top=�$��25��$��200,125,0,0q�$��2���� -I   $	 no6��$��6��$
��Left=�$��25��$	��Top=�$��25��$��1��$��2���� -J   $ A6��$
��Left=�$��25��$	��Top=�$��25��$��1��$��1��$��2���� -K   $ B6��$
��Left=�$��25��$	��Top=�$��25��$��2��$��1��$��2���� -L   $ C6��$
��Left=�$��25��$	��Top=�$��25��$��25,0,0,0q�$��2��$��1��$��2���� -M   $ D6��$
��Left=�$��25��$	��Top=�$��25��$��50,0,0,0q�$��2��$��1��$��2���� -N   $ E6��$
��Left=�$��25��$	��Top=�$��25��$��75,0,0,0q�$��2��$��1��$��2���� -O   $ F6��$
��Left=�$��25��$	��Top=�$��25��$��	100,0,0,0q�$��2��$��1��$��2���� -P   $ G6��$
��Left=�$��25��$	��Top=�$��25��$��	125,0,0,0q�$��2��$��1��$��2���� -Q   $ H6��$
��Left=�$��25��$	��Top=�$��25��$��	150,0,0,0q�$��2��$��1��$��2���� -R   $ I6��$
��Left=�$��25��$	��Top=�$��25��$��	175,0,0,0q�$��2��$��1��$��2���� -S   $ J6��$
��Left=�$��25��$	��Top=�$��25��$��	200,0,0,0q�$��2��$��1��$��2���� -T   $ n7��$��7��$
��Left=�$��25��$	��Top=�$��25��$��2��$��2���� -U   $ A7��$
��Left=�$��25��$	��Top=�$��25��$��2��$��1��$��2���� -V   $ B7��$
��Left=�$��25��$	��Top=�$��25��$��2��$��2��$��2���� -W   $ C7��$
��Left=�$��25��$	��Top=�$��25��$��25,0,0,0q�$��2��$��2��$��2���� -X   $ D7��$
��Left=�$��25��$	��Top=�$��25��$��50,0,0,0q�$��2��$��2��$��2���� -Y   $ E7��$
��Left=�$��25��$	��Top=�$��25��$��75,0,0,0q�$��2��$��2��$��2���� -Z   $ F7��$
��Left=�$��25��$	��Top=�$��25��$��	100,0,0,0q�$��2��$��2��$��2���� -[   $ G7��$
��Left=�$��25��$	��Top=�$��25��$��	125,0,0,0q�$��2��$��2��$��2���� -\   $ H7��$
��Left=�$��25��$	��Top=�$��25��$��	150,0,0,0q�$��2��$��2��$��2���� -]   $ I7��$
��Left=�$��25��$	��Top=�$��25��$��	175,0,0,0q�$��2��$��2��$��2���� -^   $ J7��$
��Left=�$��25��$	��Top=�$��25��$��	200,0,0,0q�$��2��$��2��$��2���� -_   $	 no8��$��8��$
��Left=�$��25��$	��Top=�$��25��$��0,1,0,0q�$��3���� -`   $ A8��$
��Left=�$��25��$	��Top=�$��25��$��0,1,0,0q�$��3��$��1���� -a   $ B8��$
��Left=�$��25��$	��Top=�$��25��$��0,1,0,0q�$��3��$��2���� -b   $ C8��$
��Left=�$��25��$	��Top=�$��25��$��25,1,0,0q�$��3��$��2���� -c   $ D8��$
��Left=�$��25��$	��Top=�$��25��$��50,1,0,0q�$��3��$��2���� -d   $ E8��$
��Left=�$��25��$	��Top=�$��25��$��75,1,0,0q�$��3��$��2���� -e   $ F8��$
��Left=�$��25��$	��Top=�$��25��$��	100,1,0,0q�$��3��$��2���� -f   $ G8��$
��Left=�$��25��$	��Top=�$��25��$��	125,1,0,0q�$��3��$��2���� -g   $ H8��$
��Left=�$��25��$	��Top=�$��25��$��	150,1,0,0q�$��3��$��2���� -h   $ I8��$
��Left=�$��25��$	��Top=�$��25��$��	175,1,0,0q�$��3��$��2���� -i   $ J8��$
��Left=�$��25��$	��Top=�$��25��$��	200,1,0,0q�$��3��$��2���� -j   $	 no9��$��9��$
��Left=�$��25��$	��Top=�$��25��$��4��$��2���� -k   $ A9��$
��Left=�$��25��$	��Top=�$��25��$��4��$��1��$��2���� -l   $ B9��$
��Left=�$��25��$	��Top=�$��25��$��4��$��2��$��2���� -m   $ C9��$
��Left=�$��25��$	��Top=�$��25��$��25,0,0,0q�$��4��$��2��$��2���� -n   $ D9��$
��Left=�$��25��$	��Top=�$��25��$��50,0,0,0q�$��4��$��2��$��2���� -o   $ E9��$
��Left=�$��25��$	��Top=�$��25��$��75,0,0,0q�$��4��$��2��$��2���� -p   $ F9��$
��Left=�$��25��$	��Top=�$��25��$��	100,0,0,0q�$��4��$��2��$��2���� -q   $ G9��$
��Left=�$��25��$	��Top=�$��25��$��	125,0,0,0q�$��4��$��2��$��2���� -r   $ H9��$
��Left=�$��25��$	��Top=�$��25��$��	150,0,0,0q�$��4��$��2��$��2���� -s   $ I9��$
��Left=�$��25��$	��Top=�$��25��$��	175,0,0,0q�$��4��$��2��$��2���� -t   $ J9��$
��Left=�$��25��$	��Top=�$��25��$��	200,0,0,0q�$��4��$��2��$��2���� -u   $
 no10��$��10��$
��Left=�$��25��$	��Top=�$��25��$��0,13,0,0q�$��5���� -v   $	 A10��$
��Left=�$��25��$	��Top=�$��25��$��0,13,0,0q�$��5��$��1���� -w   $	 B10��$
��Left=�$��25��$	��Top=�$��25��$��0,13,0,0q�$��5��$��2���� -x   $	 C10��$
��Left=�$��25��$	��Top=�$��25��$��	25,13,0,0q�$��5��$��2���� -y   $	 D10��$
��Left=�$��25��$	��Top=�$��25��$��	50,13,0,0q�$��5��$��2���� -z   $	 E10��$
��Left=�$��25��$	��Top=�$��25��$��	75,13,0,0q�$��5��$��2���� -{   $	 F10��$
��Left=�$��25��$	��Top=�$��25��$��
100,13,0,0q�$��5��$��2���� -|   $	 G10��$
��Left=�$��25��$	��Top=�$��25��$��
125,13,0,0q�$��5��$��2���� -}   $	 H10��$
��Left=�$��25��$	��Top=�$��25��$��
150,13,0,0q�$��5��$��2���� -~   $	 I10��$
��Left=�$��25��$	��Top=�$��25��$��
175,13,0,0q�$��5��$��2���� -   $	 J10��$
��Left=�$��25��$	��Top=�$��25��$��
200,13,0,0q�$��5��$��2��� -�   $ PlayerTargetTable��$��497,54,10,79q�.+��� -�   $
 no_t��$
��Left=�$��25��$	��Top=�$��25���� -�   $	 A_t��$��A��$
��Left=�$��25��$	��Top=�$��25��$��25,0,0,0q��� -�   $	 B_t��$��B��$
��Left=�$��25��$	��Top=�$��25��$��50,0,0,0q��� -�   $	 C_t��$��C��$
��Left=�$��25��$	��Top=�$��25��$��75,0,0,0q��� -�   $	 D_t��$��D��$
��Left=�$��25��$	��Top=�$��25��$��	100,0,0,0q��� -�   $	 E_t��$��E��$
��Left=�$��25��$	��Top=�$��25��$��	125,0,0,0q��� -�   $	 F_t��$��F��$
��Left=�$��25��$	��Top=�$��25��$��	150,0,0,0q��� -�   $	 G_t��$��G��$
��Left=�$��25��$	��Top=�$��25��$��	175,0,0,0q��� -�   $	 H_t��$��H��$
��Left=�$��25��$	��Top=�$��25��$��	200,0,0,0q��� -�   $	 I_t��$��I��$
��Left=�$��25��$	��Top=�$��25��$��	225,0,0,0q��� -�   $	 J_t��$��J��$
��Left=�$��25��$	��Top=�$��25��$��	250,0,0,0q��� -�   $ no1_t��$��1��$
��Left=�$��25��$	��Top=�$��25��$��0,25,0,0q��� -�   $
 A1_t��$
��Left=�$��25��$	��Top=�$��25��$��	25,25,0,0q��� -�   $
 B1_t��$
��Left=�$��25��$	��Top=�$��25��$��	50,25,0,0q��� -�   $
 C1_t��$
��Left=�$��25��$	��Top=�$��25��$��	75,25,0,0q��� -�   $
 D1_t��$
��Left=�$��25��$	��Top=�$��25��$��
100,25,0,0q��� -�   $
 E1_t��$
��Left=�$��25��$	��Top=�$��25��$��
125,25,0,0q��� -�   $
 F1_t��$
��Left=�$��25��$	��Top=�$��25��$��
150,25,0,0q��� -�   $
 G1_t��$
��Left=�$��25��$	��Top=�$��25��$��
175,25,0,0q��� -�   $
 H1_t��$
��Left=�$��25��$	��Top=�$��25��$��
200,25,0,0q��� -�   $
 I1_t��$
��Left=�$��25��$	��Top=�$��25��$��
225,25,0,0q��� -�   $
 J1_t��$
��Left=�$��25��$	��Top=�$��25��$��
250,25,0,0q��� -�   $ no2_t��$��2��$
��Left=�$��25��$	��Top=�$��25��$��0,50,0,0q��� -�   $
 A2_t��$
��Left=�$��25��$	��Top=�$��25��$��	25,50,0,0q��� -�   $
 B2_t��$
��Left=�$��25��$	��Top=�$��25��$��	50,50,0,0q��� -�   $
 C2_t��$
��Left=�$��25��$	��Top=�$��25��$��	75,50,0,0q��� -�   $
 D2_t��$
��Left=�$��25��$	��Top=�$��25��$��
100,50,0,0q��� -�   $
 E2_t��$
��Left=�$��25��$	��Top=�$��25��$��
125,50,0,0q��� -�   $
 F2_t��$
��Left=�$��25��$	��Top=�$��25��$��
150,50,0,0q��� -�   $
 G2_t��$
��Left=�$��25��$	��Top=�$��25��$��
175,50,0,0q��� -�   $
 H2_t��$
��Left=�$��25��$	��Top=�$��25��$��
200,50,0,0q��� -�   $
 I2_t��$
��Left=�$��25��$	��Top=�$��25��$��
225,50,0,0q��� -�   $
 J2_t��$
��Left=�$��25��$	��Top=�$��25��$��
250,50,0,0q��� -�   $ no3_t��$��3��$
��Left=�$��25��$	��Top=�$��25��$��0,75,0,0q��� -�   $
 A3_t��$
��Left=�$��25��$	��Top=�$��25��$��	25,75,0,0q��� -�   $
 B3_t��$
��Left=�$��25��$	��Top=�$��25��$��	50,75,0,0q��� -�   $
 C3_t��$
��Left=�$��25��$	��Top=�$��25��$��	75,75,0,0q��� -�   $
 D3_t��$
��Left=�$��25��$	��Top=�$��25��$��
100,75,0,0q��� -�   $
 E3_t��$
��Left=�$��25��$	��Top=�$��25��$��
125,75,0,0q��� -�   $
 F3_t��$
��Left=�$��25��$	��Top=�$��25��$��
150,75,0,0q��� -�   $
 G3_t��$
��Left=�$��25��$	��Top=�$��25��$��
175,75,0,0q��� -�   $
 H3_t��$
��Left=�$��25��$	��Top=�$��25��$��
200,75,0,0q��� -�   $
 I3_t��$
��Left=�$��25��$	��Top=�$��25��$��
225,75,0,0q��� -�   $
 J3_t��$
��Left=�$��25��$	��Top=�$��25��$��
250,75,0,0q��� -�   $ no4_t��$��4��$
��Left=�$��25��$	��Top=�$��25��$��	0,100,0,0q��� -�   $
 A4_t��$
��Left=�$��25��$	��Top=�$��25��$��
25,100,0,0q��� -�   $
 B4_t��$
��Left=�$��25��$	��Top=�$��25��$��
50,100,0,0q��� -�   $
 C4_t��$
��Left=�$��25��$	��Top=�$��25��$��
75,100,0,0q��� -�   $
 D4_t��$
��Left=�$��25��$	��Top=�$��25��$��100,100,0,0q��� -�   $
 E4_t��$
��Left=�$��25��$	��Top=�$��25��$��125,100,0,0q��� -�   $
 F4_t��$
��Left=�$��25��$	��Top=�$��25��$��150,100,0,0q��� -�   $
 G4_t��$
��Left=�$��25��$	��Top=�$��25��$��175,100,0,0q��� -�   $
 H4_t��$
��Left=�$��25��$	��Top=�$��25��$��200,100,0,0q��� -�   $
 I4_t��$
��Left=�$��25��$	��Top=�$��25��$��225,100,0,0q��� -�   $
 J4_t��$
��Left=�$��25��$	��Top=�$��25��$��250,100,0,0q��� -�   $ no5_t��$��5��$
��Left=�$��25��$	��Top=�$��25��$��	0,125,0,0q��� -�   $
 A5_t��$
��Left=�$��25��$	��Top=�$��25��$��
25,125,0,0q��� -�   $
 B5_t��$
��Left=�$��25��$	��Top=�$��25��$��
50,125,0,0q��� -�   $
 C5_t��$
��Left=�$��25��$	��Top=�$��25��$��
75,125,0,0q��� -�   $
 D5_t��$
��Left=�$��25��$	��Top=�$��25��$��100,125,0,0q��� -�   $
 E5_t��$
��Left=�$��25��$	��Top=�$��25��$��125,125,0,0q��� -�   $
 F5_t��$
��Left=�$��25��$	��Top=�$��25��$��150,125,0,0q��� -�   $
 G5_t��$
��Left=�$��25��$	��Top=�$��25��$��175,125,0,0q��� -�   $
 H5_t��$
��Left=�$��25��$	��Top=�$��25��$��200,125,0,0q��� -�   $
 I5_t��$
��Left=�$��25��$	��Top=�$��25��$��225,125,0,0q��� -�   $
 J5_t��$
��Left=�$��25��$	��Top=�$��25��$��250,125,0,0q��� -�   $ no6_t��$��6��$
��Left=�$��25��$	��Top=�$��25��$��	0,150,0,0q��� -�   $
 A6_t��$
��Left=�$��25��$	��Top=�$��25��$��
25,150,0,0q��� -�   $
 B6_t��$
��Left=�$��25��$	��Top=�$��25��$��
50,150,0,0q��� -�   $
 C6_t��$
��Left=�$��25��$	��Top=�$��25��$��
75,150,0,0q��� -�   $
 D6_t��$
��Left=�$��25��$	��Top=�$��25��$��100,150,0,0q��� -�   $
 E6_t��$
��Left=�$��25��$	��Top=�$��25��$��125,150,0,0q��� -�   $
 F6_t��$
��Left=�$��25��$	��Top=�$��25��$��150,150,0,0q��� -�   $
 G6_t��$
��Left=�$��25��$	��Top=�$��25��$��175,150,0,0q��� -�   $
 H6_t��$
��Left=�$��25��$	��Top=�$��25��$��200,150,0,0q��� -�   $
 I6_t��$
��Left=�$��25��$	��Top=�$��25��$��225,150,0,0q��� -�   $
 J6_t��$
��Left=�$��25��$	��Top=�$��25��$��250,150,0,0q��� -�   $
 n7_t��$��7��$
��Left=�$��25��$	��Top=�$��25��$��	0,175,0,0q��� -�   $
 A7_t��$
��Left=�$��25��$	��Top=�$��25��$��
25,175,0,0q��� -�   $
 B7_t��$
��Left=�$��25��$	��Top=�$��25��$��
50,175,0,0q��� -�   $
 C7_t��$
��Left=�$��25��$	��Top=�$��25��$��
75,175,0,0q��� -�   $
 D7_t��$
��Left=�$��25��$	��Top=�$��25��$��100,175,0,0q��� -�   $
 E7_t��$
��Left=�$��25��$	��Top=�$��25��$��125,175,0,0q��� -�   $
 F7_t��$
��Left=�$��25��$	��Top=�$��25��$��150,175,0,0q��� -�   $
 G7_t��$
��Left=�$��25��$	��Top=�$��25��$��175,175,0,0q��� -�   $
 H7_t��$
��Left=�$��25��$	��Top=�$��25��$��200,175,0,0q��� -�   $
 I7_t��$
��Left=�$��25��$	��Top=�$��25��$��225,175,0,0q��� -�   $
 J7_t��$
��Left=�$��25��$	��Top=�$��25��$��250,175,0,0q��� -�   $ no8_t��$��8��$
��Left=�$��25��$	��Top=�$��25��$��	0,200,0,0q��� -�   $
 A8_t��$
��Left=�$��25��$	��Top=�$��25��$��
25,200,0,0q��� -�   $
 B8_t��$
��Left=�$��25��$	��Top=�$��25��$��
50,200,0,0q��� -�   $
 C8_t��$
��Left=�$��25��$	��Top=�$��25��$��
75,200,0,0q��� -�   $
 D8_t��$
��Left=�$��25��$	��Top=�$��25��$��100,200,0,0q��� -�   $
 E8_t��$
��Left=�$��25��$	��Top=�$��25��$��125,200,0,0q��� -�   $
 F8_t��$
��Left=�$��25��$	��Top=�$��25��$��150,200,0,0q��� -�   $
 G8_t��$
��Left=�$��25��$	��Top=�$��25��$��175,200,0,0q��� -�   $
 H8_t��$
��Left=�$��25��$	��Top=�$��25��$��200,200,0,0q��� -�   $
 I8_t��$
��Left=�$��25��$	��Top=�$��25��$��225,200,0,0q��� -�   $
 J8_t��$
��Left=�$��25��$	��Top=�$��25��$��250,200,0,0q��� -�   $ no9_t��$��9��$
��Left=�$��25��$	��Top=�$��25��$��	0,225,0,0q��� -�   $
 A9_t��$
��Left=�$��25��$	��Top=�$��25��$��
25,225,0,0q��� -�   $
 B9_t��$
��Left=�$��25��$	��Top=�$��25��$��
50,225,0,0q��� -�   $
 C9_t��$
��Left=�$��25��$	��Top=�$��25��$��
75,225,0,0q��� -�   $
 D9_t��$
��Left=�$��25��$	��Top=�$��25��$��100,225,0,0q��� -�   $
 E9_t��$
��Left=�$��25��$	��Top=�$��25��$��125,225,0,0q��� -�   $
 F9_t��$
��Left=�$��25��$	��Top=�$��25��$��150,225,0,0q��� -�   $
 G9_t��$
��Left=�$��25��$	��Top=�$��25��$��175,225,0,0q��� -�   $
 H9_t��$
��Left=�$��25��$	��Top=�$��25��$��200,225,0,0q��� -�   $
 I9_t��$
��Left=�$��25��$	��Top=�$��25��$��225,225,0,0q��� -�   $
 J9_t��$
��Left=�$��25��$	��Top=�$��25��$��250,225,0,0q��� -�   $ no10_t��$��10��$
��Left=�$��25��$	��Top=�$��25��$��	0,250,0,0q��� -�   $ A10_t��$
��Left=�$��25��$	��Top=�$��25��$��
25,250,0,0q��� -�   $ B10_t��$
��Left=�$��25��$	��Top=�$��25��$��
50,250,0,0q��� -�   $ C10_t��$
��Left=�$��25��$	��Top=�$��25��$��
75,250,0,0q��� -�   $ D10_t��$
��Left=�$��25��$	��Top=�$��25��$��100,250,0,0q��� -�   $ E10_t��$
��Left=�$��25��$	��Top=�$��25��$��125,250,0,0q��� -�   $ F10_t��$
��Left=�$��25��$	��Top=�$��25��$��150,250,0,0q��� -�   $ G10_t��$
��Left=�$��25��$	��Top=�$��25��$��175,250,0,0q��� -�   $ H10_t��$
��Left=�$��25��$	��Top=�$��25��$��200,250,0,0q��� -�   $ I10_t��$
��Left=�$��25��$	��Top=�$��25��$��225,250,0,0q��� -�   $ J10_t��$
��Left=�$��25��$	��Top=�$��25��$��250,250,0,0q��� $��
Your Ships��$
��Left=�$��
109,26,0,0q�$	��Top=��� $��Your Targets��$
��Left=�$��
614,23,0,0q�$	��Top=��� -�    ��Name$ 
PatrolBoat��$
��Left=�$��
10,341,0,0q�$	��Top=�$��50��$#��Resources/small_Ship_full.png�� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� �� T� �� -�   $ 	Submarine��$
��Left=�$��
80,341,0,0q�$	��Top=�$��46��$#��Resources/small_Ship_full.png��$��12��$ 0.5,0.5&�z�V� .~���  �� ScaleX$	 1.5Q��� �� T� �� -�   $ 	Destroyer��$
��Left=�$��162,341,0,0q�$	��Top=�$��46��$#��Resources/small_Ship_full.png��$��12��$ 0.5,0.5&�z�V� .~��� $	 1.5Q��� �� T� �� -�   $ 
Battleship��$
��Left=�$��
27,380,0,0q�$	��Top=�$��46��$#��Resources/small_Ship_full.png��$��12��$ 0.5,0.5&�z�V� .~��� $ 2Q�T� �� -�   $ Carrier��$
��Left=�$��141,380,0,0q�$	��Top=�$��46��$#��Resources/small_Ship_full.png��$��12��$ 0.5,0.5&�z�V� .~��� $	 2.5Q��� �� T� �� $$��Remaining Ships for the enemy:��$		 497��$	
 341���� -�   $ enemy_remaining_ships��$��0��$��26��$		 675��$	
 341��$��50���� $��Your Remaining Ships:��$		 497��$	
 372���� -   $ player_remaining_ships��$��0��$��26��$		 630��$	
 372��$��50���� $��
Your hits:��$		 497��$	
 403���� $��Enemy hits:��$		 605��$	
 403���� -  $ NumberofHits��$��0��$��26��$		 561��$	
 403��$��23���� -  $ NumberofHitsEnemy��$��0��$��26��$		 680��$	
 403��$��23��