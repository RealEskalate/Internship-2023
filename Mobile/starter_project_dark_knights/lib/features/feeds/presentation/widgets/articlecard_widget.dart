import 'package:flutter/material.dart';
import 'articleInfo_widget.dart';
import 'articleImage_widget.dart';

class ArticleCard extends StatelessWidget {
  const ArticleCard({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    final screenHeight = MediaQuery.of(context).size.height;
    return Material(
      shadowColor: Colors.white,
      elevation: 3,
      borderRadius: BorderRadius.circular(20),
      child: Padding(
        padding: const EdgeInsets.all(15),
        child: Container(
            height: screenHeight * 0.25,
            decoration: BoxDecoration(
              borderRadius: BorderRadius.circular(20),
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
