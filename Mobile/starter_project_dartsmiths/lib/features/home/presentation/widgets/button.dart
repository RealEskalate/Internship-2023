import 'package:dartsmiths/core/utils/style.dart';
import 'package:flutter/material.dart';

class MyButton extends StatelessWidget {
  String text;
  bool active = false;
  MyButton({super.key, required this.text,required this.active});

  @override
  Widget build(BuildContext context) {
    
    return Container(
      decoration: BoxDecoration(
          color: active? Color(0xFF376AED):Colors.white,
          borderRadius: BorderRadius.circular(120),
          border: Border.all(
            color:  Color(0xFF376AED),
            width: 2,
          )),
      width: 85,
      height: 40,
      child: Center(child: Text(text, style: active? myTextStyle.copyWith(color: Colors.white):myTextStyle)),
    );
  }
}
