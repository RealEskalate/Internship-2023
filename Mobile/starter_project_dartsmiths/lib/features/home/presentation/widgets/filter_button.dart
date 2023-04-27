import 'package:dartsmiths/core/utils/style.dart';
import 'package:flutter/material.dart';

class FilterButton extends StatelessWidget {
  String text;
  bool isActive = false;
  FilterButton({super.key, required this.text, required this.isActive});

  @override
  Widget build(BuildContext context) {
    return Container(
      decoration: BoxDecoration(
          color: isActive ? Color(0xFF376AED) : Colors.white,
          borderRadius: BorderRadius.circular(120),
          border: Border.all(
            color: Color(0xFF376AED),
            width: 2,
          )),
      width: 85,
      height: 40,
      child: Center(
          child: Text(text,
              style: isActive
                  ? myTextStyle.copyWith(color: Colors.white)
                  : myTextStyle)),
    );
  }
}
