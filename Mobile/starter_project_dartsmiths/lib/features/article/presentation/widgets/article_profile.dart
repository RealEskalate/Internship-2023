import 'package:dartsmiths/core/utils/colors.dart';
import 'package:flutter/material.dart';
import '../../../../core/utils/images.dart';
import '../../../../core/utils/ui_converter.dart';



class ArticleProfile extends StatelessWidget {
  ArticleProfile({super.key});
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
                  BorderRadius.circular(UIConverter.getComponentWidth(context, 15)),
              child: Image.asset(
                articleReadingFasionImage1,
                width: UIConverter.getComponentWidth(context, 38),
                height: UIConverter.getComponentHeight(context, 38),
              ),
            ),
            SizedBox(
              width: UIConverter.getComponentHeight(context, 13),
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
              ],
            ),
          ],
        ),
        const Icon(Icons.bookmark_add_outlined)
      ],
    );
  }
}
