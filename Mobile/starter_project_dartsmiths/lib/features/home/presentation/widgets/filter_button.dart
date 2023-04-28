import 'package:dartsmiths/core/utils/colors.dart';
import 'package:dartsmiths/core/utils/style.dart';
import 'package:flutter/material.dart';

import '../../../../core/utils/ui_converter.dart';

class FilterButton extends StatelessWidget {
  String text;
  bool isActive = false;
  FilterButton({super.key, required this.text, required this.isActive});

  @override
  Widget build(BuildContext context) {
    return Container(
      decoration: BoxDecoration(
          color: isActive ? primaryColor : whiteColor,
          borderRadius:
              BorderRadius.circular(UIConverter.getComponentWidth(context, 35)),
          border: Border.all(
            color: primaryColor,
            width: UIConverter.getComponentWidth(context, 2),
          )),
      width: UIConverter.getComponentWidth(context, 65),
      height: UIConverter.getComponentHeight(context, 45),
      child: Center(
          child: Text(text,
              style: isActive
                  ? myTextStyle.copyWith(color: whiteColor)
                  : myTextStyle.copyWith(color: primaryColor))),
    );
  }
}
