import 'package:dark_knights/core/utils/colors.dart';
import 'package:dark_knights/core/utils/converter.dart';
import 'package:flutter/material.dart';

class HeaderIconButtons extends StatelessWidget {
  const HeaderIconButtons({super.key});

  @override
  Widget build(BuildContext context) {
    double top = convertPixle(59, "height", context);
    double left = convertPixle(50, "width", context);
    double right = convertPixle(46, "width", context);

    double arrowHeight = convertPixle(20, "width", context);
    double moreButtonSize = convertPixle(25, "width", context);

    return Padding(
      padding: EdgeInsets.only(top: top, left: left, right: right),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          IconButton(
              iconSize: arrowHeight,
              onPressed: () {},
              icon: Icon(
                Icons.arrow_back_ios,
                color: primaryTextColor,
                size: arrowHeight,
              )),
          IconButton(
              iconSize: arrowHeight,
              onPressed: () {},
              icon: Icon(
                Icons.more_horiz,
                color: primaryTextColor,
                size: moreButtonSize,
              )),
        ],
      ),
    );
  }
}
