// ignore_for_file: prefer_const_constructors

import 'package:dark_knights/core/utils/colors.dart';
import 'package:dark_knights/core/utils/converter.dart';
import 'package:dark_knights/features/example/presentation/widgets/profile_picture.dart';
import 'package:flutter/material.dart';

Widget userInfo(context) {
  double fontSize = convertPixle(14, "width", context);
  double iconSize = convertPixle(21, "width", context);
  return Row(
    mainAxisAlignment: MainAxisAlignment.spaceBetween,
    children: [
      Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          Padding(
              padding: EdgeInsets.only(right: 10),
              child: profilePicture(context)),
          Column(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text(
                'Richard Gervain',
                style: TextStyle(
                    fontSize: fontSize,
                    color: secondaryTextColor,
                    fontFamily: 'Urbanist'),
              ),
              Text(
                "2m ago",
                style: TextStyle(
                  fontSize: fontSize,
                  fontWeight: FontWeight.w600,
                  fontFamily: 'Poppins',
                ),
              ),
            ],
          )
        ],
      ),
      IconButton(
        iconSize: iconSize,
        icon: const Icon(
          Icons.bookmark_border,
          color: primaryColor,
        ),
        onPressed: () {},
      )
    ],
  );
}
