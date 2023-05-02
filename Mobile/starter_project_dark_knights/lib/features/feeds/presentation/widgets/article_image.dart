import 'package:dark_knights/core/utils/colors.dart';
import 'package:flutter/material.dart';

class ArticleImage extends StatelessWidget {
  const ArticleImage({
    super.key,
    required this.readTime
  });
  final int readTime;

  @override
  Widget build(BuildContext context) {
    final screenHeight = MediaQuery.of(context).size.height;
    final screenWidth = MediaQuery.of(context).size.width;
    return Stack(
      children: [
        Container(
            height: screenHeight * 0.18,
            decoration: BoxDecoration(
                borderRadius: BorderRadius.circular(screenHeight * 0.01),
                image: const DecorationImage(
                    image: AssetImage("assets/images/article_pic.jpg"),
                    fit: BoxFit.fill))),
        Padding(
          padding: EdgeInsets.all(screenHeight * 0.008),
          child: Container(
            width: screenWidth * 0.22,
            height: screenHeight * 0.04,
            decoration: BoxDecoration(
                color: whiteColor,
                borderRadius: BorderRadius.circular(screenHeight * 0.01)),
            child:  Center(
                child: Text("$readTime min read",
                    style: const TextStyle(
                      fontFamily: "Poppins",
                      fontWeight: FontWeight.w500,
                      color: textColor2,
                    ))),
          ),
        )
      ],
    );
  }
}
