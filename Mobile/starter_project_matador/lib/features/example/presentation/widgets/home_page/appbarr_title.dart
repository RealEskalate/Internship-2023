import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:matador/core/constants/colors.dart';
import 'package:matador/core/utils/real_pixel_to_logical_pixel.dart';

class AppBarrTitle extends StatelessWidget {
  const AppBarrTitle({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Center(
      child: Text(
        "Welcome Back!",
        style: GoogleFonts.poppins(
          color: defaultTextColor,
          fontWeight: FontWeight.w600,
          fontSize: convertPixelToScreenWidth(context, 27),
          height: convertPixelToScreenHeight(context, 40) /
              convertPixelToScreenWidth(context, 27),
        ),
      ),
    );
  }
}
