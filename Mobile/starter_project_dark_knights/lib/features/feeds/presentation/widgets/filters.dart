import 'package:dark_knights/core/utils/colors.dart';
import 'package:flutter/material.dart';

class Filters extends StatelessWidget {
  Filters({super.key, required this.label, this.active = false});
  String label;
  bool active;
  @override
  Widget build(BuildContext context) {
    final screenWidth = MediaQuery.of(context).size.width;
    return FilterChip(
      backgroundColor: active == false ? whiteColor : primaryColor,
      labelPadding:
          EdgeInsets.fromLTRB(screenWidth * 0.03, 0, screenWidth * 0.03, 0),
      label: Text(label,
          style: TextStyle(
              fontFamily: "Poppins",
              fontWeight: FontWeight.w500,
              color: active == false ? primaryColor : whiteColor)),
      onSelected: (value) {},
      side: const BorderSide(color: primaryColor, width: 3),
    );
  }
}
