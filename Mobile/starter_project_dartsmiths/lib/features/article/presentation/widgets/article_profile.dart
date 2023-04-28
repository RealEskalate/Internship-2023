import 'package:dartsmiths/core/utils/colors.dart';
import 'package:flutter/material.dart';
import '../../../../core/utils/images.dart';
import '../../../../core/utils/ui_converter.dart';



class article_profile extends StatelessWidget {
  article_profile({super.key});
  String name = 'Richard Gervan';
String post_time = '2m';

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceBetween,
      children: [
        Row(
          children: [
            ClipRRect(
              borderRadius:
                  BorderRadius.circular(UIConverter.designWidth * 0.3),
              child: Image.asset(
                articleReadingFasionImage1,
                width: UIConverter.designWidth * 0.1,
                height: UIConverter.designHeight * 0.06,
              ),
            ),
            SizedBox(
              width: UIConverter.getComponentHeight(context, 10),
            ),
            Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(
                  name,
                  style: const TextStyle(color: secondaryColor),
                ),
                Text(
                  post_time,
                  style: const TextStyle(color: secondaryColor),
                ),
                SizedBox(width: 10,)
              ],
            ),
          ],
        ),
        const Icon(Icons.bookmark_add_outlined)
      ],
    );
  }
}
