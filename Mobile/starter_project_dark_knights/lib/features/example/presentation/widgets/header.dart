import 'package:dark_knights/core/utils/colors.dart';
import 'package:dark_knights/core/utils/converter.dart';

import 'package:dark_knights/features/example/presentation/widgets/user_info.dart';
import 'package:flutter/material.dart';

Widget header(context) {
  double left = convertPixle(40, "width", context);
  double right = convertPixle(45, "width", context);
  double textPadding = convertPixle(28, "height", context);
  double fontSize = convertPixle(24, "width", context);

  return Padding(
    padding: EdgeInsets.only(left: left, right: right),
    child: Column(children: [
      Padding(
        padding: EdgeInsets.symmetric(vertical: textPadding),
        child: Text(
          'Four Things Eveyone Needs To Know',
          style: TextStyle(
              fontSize: fontSize,
              fontWeight: FontWeight.w700,
              color: primaryTextColor),
        ),
      ),
      userInfo(context),
    ]),
  );
}
