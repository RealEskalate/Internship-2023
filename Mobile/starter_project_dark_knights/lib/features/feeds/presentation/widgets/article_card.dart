import 'package:flutter/material.dart';
import 'article_info.dart';
import 'article_image.dart';
import '../../../../core/utils/colors.dart';

class ArticleCard extends StatelessWidget {
  const ArticleCard({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    final screenHeight = MediaQuery.of(context).size.height;
    return Material(
      shadowColor: whiteColor,
      elevation: 3,
      borderRadius: BorderRadius.circular(screenHeight * 0.02),
      child: Padding(
        padding: EdgeInsets.all(screenHeight * 0.015),
        child: Container(
            height: screenHeight * 0.25,
            decoration: BoxDecoration(
              borderRadius: BorderRadius.circular(screenHeight * 0.02),
            ),
            child: Column(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              crossAxisAlignment: CrossAxisAlignment.end,
              children: [
                Row(
                  children: const [
                    Expanded(
                      child: ArticleImage(),
                    ),
                    ArticleInfo()
                  ],
                ),
                const Text(
                  "Jan 12,2022",
                  style: TextStyle(
                    fontFamily: "Poppins",
                    fontWeight: FontWeight.w200,
                  ),
                )
              ],
            )),
      ),
    );
  }
}
