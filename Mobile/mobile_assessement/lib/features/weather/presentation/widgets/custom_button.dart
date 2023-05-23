import 'package:flutter/material.dart';

import '../../../../core/utils/colors.dart';
import '../../../../core/utils/ui_converter.dart';

class CustomButton extends StatelessWidget {
  const CustomButton({required this.onTap, required this.text, super.key});
  final void Function()? onTap;
  final String text;
  @override
  Widget build(BuildContext context) {
    return InkWell(
        onTap: onTap,
        child: Container(
          child: Center(child: Text(text,style: TextStyle(color: whiteColor))),
            decoration: BoxDecoration(
                borderRadius: BorderRadius.circular(10), color: secondaryColor),
            height: UIConverter.getComponentHeight(context, 56),
            width: UIConverter.getComponentHeight(context, 84)));
  }
}
