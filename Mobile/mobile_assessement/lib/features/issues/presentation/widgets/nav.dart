import 'package:flutter/cupertino.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';

import '../../../../core/utils/colors.dart';
import '../../../../core/utils/style.dart';

class NavBar extends StatelessWidget {
  String text;
  bool isActive = false;
  NavBar({super.key, required this.text, required this.isActive});
  
 
  @override
  Widget build(BuildContext context) {
    return Container(
      
          child: Center(child: Text(text, style: isActive? myTextStyle.copyWith(color: Color(0xFF203D54))
                  : myTextStyle.copyWith(color: Color(0xFF73818C)))),
          
    );
  }
}
