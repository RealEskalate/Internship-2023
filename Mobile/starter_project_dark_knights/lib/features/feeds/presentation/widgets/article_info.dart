import 'package:dark_knights/core/utils/colors.dart';
import 'package:flutter/material.dart';
import 'dart:math';

class ArticleInfo extends StatelessWidget {
  const ArticleInfo(
      {super.key,
      required this.articleTitle,
      required this.articleType,
      required this.author});
  final String articleTitle;
  final String author;
  final String articleType;

  @override
  Widget build(BuildContext context) {
    final screenWidth = MediaQuery.of(context).size.width;
    final screenHeight = MediaQuery.of(context).size.height;
    return Expanded(
        flex: 1,
        child: Container(
          margin: EdgeInsets.fromLTRB(screenWidth * 0.04, 0, 0, 0),
          height: screenHeight * 0.19,
          child: Column(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text(
                articleTitle,
                style: TextStyle(
                    fontSize: min(screenWidth * 0.04, screenHeight * 0.03),
                    fontFamily: "Urbanist",
                    fontWeight: FontWeight.w700,
                    color: textColor1),
              ),
              ElevatedButton(
                  style: ElevatedButton.styleFrom(
                    backgroundColor: tertiaryColor,
                    minimumSize: Size(screenWidth * 0.1, screenHeight * 0.033),
                  ),
                  onPressed: () {},
                  child: Text(
                    articleType,
                    style: const TextStyle(
                        fontFamily: "Poppins", fontWeight: FontWeight.w700),
                  )),
              Text(
                author,
                style: const TextStyle(
                  fontFamily: "Poppins",
                ),
              )
            ],
          ),
        ));
  }
}
