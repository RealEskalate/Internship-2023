import 'package:flutter/material.dart';

class Filters extends StatelessWidget {
  Filters({super.key, required this.lable, this.active = false});
  String lable;
  bool active;
  @override
  Widget build(BuildContext context) {
    final screenWidth = MediaQuery.of(context).size.width;
    return FilterChip(
      backgroundColor: active == false ? Colors.white : const Color(0xFF376AED),
      labelPadding:
          EdgeInsets.fromLTRB(screenWidth * 0.03, 0, screenWidth * 0.03, 0),
      label: Text(lable,
          style: TextStyle(
              fontFamily: "Poppins",
              fontWeight: FontWeight.w500,
              color: active == false ? const Color(0xFF376AED) : Colors.white)),
      onSelected: (value) {},
      side: const BorderSide(color: Color(0xFF376AED), width: 3),
    );
  }
}
