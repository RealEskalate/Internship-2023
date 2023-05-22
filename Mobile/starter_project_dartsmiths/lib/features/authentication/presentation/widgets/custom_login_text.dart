import 'package:flutter/material.dart';

import '../../../../core/utils/colors.dart';

class CustomLoginText extends StatelessWidget {
  const CustomLoginText({super.key, required this.str, this.customColor});

  final String str;
  final Color? customColor;

  @override
  Widget build(BuildContext context) {
    return Text(
      str,
      style: TextStyle(
        fontSize: 12,
        fontWeight: FontWeight.w600,
        color: customColor,
        fontFamily: 'Urbanist',
      ),
    );
  }
}
