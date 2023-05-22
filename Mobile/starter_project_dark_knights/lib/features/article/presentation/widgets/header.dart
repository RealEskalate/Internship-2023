// ignore_for_file: file_names

import 'package:dark_knights/core/utils/colors.dart';
import 'package:dark_knights/core/utils/converter.dart';
import 'package:flutter/material.dart';

import 'article_author_detail.dart';
import 'bookmark_icon_button.dart';

class Header extends StatelessWidget {
  final userInfo;
  const Header({super.key, required this.userInfo});

  @override
  Widget build(BuildContext context) {
    double left = convertPixle(40, "width", context);
    double right = convertPixle(45, "width", context);
    double textPadding = convertPixle(28, "height", context);
    double fontSize = convertPixle(24, "width", context);

    return Padding(
      padding: EdgeInsets.only(left: left, right: right),
      child: Column(
        children: [
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
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              ArticleAuthorDetail(
                authorName: userInfo.authorName,
                postedAt: "2m",
                profileImageUrl: userInfo.image,
              ),
              BookmarkButton()
            ],
          )
        ],
      ),
    );
  }
}
