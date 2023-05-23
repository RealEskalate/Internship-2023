import 'package:flutter/material.dart';

import '../../../../core/utils/ui_converter.dart';

class CustomTextField extends StatelessWidget {
  const CustomTextField({
    super.key,
    required this.prefixIcon,
    required this.hintText,
    required this.width,
    required this.height,
    required this.textController,
  });

  final TextEditingController textController;
  final IconData prefixIcon;
  final String hintText;
  final double width;
  final double height;

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      width: UIConverter.getComponentWidth(context, 265),
       height: UIConverter.getComponentHeight(context, 58),

      child: TextField(
        controller: textController,
      decoration: InputDecoration(
        prefixIcon: Icon(Icons.search),
        hintText: 'Search for a new city',
        filled: true,
        fillColor: Colors.white,
        border: OutlineInputBorder(
          borderRadius: BorderRadius.circular(10),
          borderSide: BorderSide.none,
        ),
        enabledBorder: OutlineInputBorder(
          borderRadius: BorderRadius.circular(10),
          borderSide: BorderSide.none,
        ),
        focusedBorder: OutlineInputBorder(
          borderRadius: BorderRadius.circular(10),
          borderSide: BorderSide.none,
        ),
      ),
    ));
  }
}
