// ignore_for_file: non_constant_identifier_names

import 'package:dartsmiths/core/utils/colors.dart';
import 'package:flutter/material.dart';
import '../../../../core/utils/ui_converter.dart';

String name = 'Richard Gervan';
String post_time = '2m';

class article_profile extends StatelessWidget {
  const article_profile({super.key});

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
                'images/fashion1.jpg',
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
                )
              ],
            ),
          ],
        ),
        const Icon(Icons.bookmark_add_outlined)
      ],
    );
  }
}
