import 'package:flutter/material.dart';
import 'package:matador/core/constants/colors.dart';
import 'package:matador/core/utils/converters/convert_to_font_size.dart';
import 'package:matador/core/utils/converters/real_pixel_to_logical_pixel.dart';

class AppBarTitle extends StatelessWidget {
  const AppBarTitle({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Center(
      child: Text(
        "Welcome Back!",
        style: TextStyle(
          fontFamily: "Poppins",
          fontWeight: FontWeight.w600,
          fontSize: convertToFontSize(
              height: convertPixelToScreenHeight(context, 40),
              width: convertPixelToScreenWidth(context, 27)),
          color: defaultTextColor,
        ),
      ),
    );
  }
}
