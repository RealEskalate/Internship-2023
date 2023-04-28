import 'package:dartsmiths/core/utils/colors.dart';
import 'package:flutter/material.dart';
import 'next_pointer.dart';

class ArticleContent extends StatefulWidget {
  const ArticleContent({super.key});

  @override
  State<ArticleContent> createState() => _ArticlePageState();
}

class _ArticlePageState extends State<ArticleContent> {
  @override
  Widget build(BuildContext context) {
    return Container(
      height: MediaQuery.of(context).size.height / 3,
      width: MediaQuery.of(context).size.width,
      decoration: const BoxDecoration(
        borderRadius: BorderRadius.only(
          topLeft: Radius.circular(24.0),
          topRight: Radius.circular(24.0),
        ),
        color: whiteColor,
      ),
      child: Padding(
        padding:
            const EdgeInsets.only(left: 40, right: 60, bottom: 10.0, top: 10.0),
        child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: const [
              Text(
                "Read the article you want instantly",
                style: TextStyle(
                  fontFamily: 'urbanist',
                  fontWeight: FontWeight.w100,
                  fontStyle: FontStyle.italic,
                  fontSize: 20,
                  color: blackColor,
                ),
              ),
              SizedBox(
                height: 10.0,
              ),
              Text(
                "You can read thousands of articles on Blog Club, save them in the application and share them with your loved ones.",
                style: TextStyle(
                    color: secondaryTextColor,
                    fontFamily: 'Poppins',
                    fontWeight: FontWeight.w900,
                    fontSize: 14,
                    fontStyle: FontStyle.normal,
                    decoration: TextDecoration.none),
              ),
              NextPointer(),
            ]),
      ),
    );
  }
}
