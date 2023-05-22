import '../../../../core/utils/colors.dart';
import '../../../../core/utils/converter.dart';
import 'package:flutter/material.dart';

import 'article_author_profile_picture.dart';

class ArticleAuthorDetail extends StatelessWidget {
  final String authorName;
  final String profileImageUrl;
  final String postedAt;
  const ArticleAuthorDetail(
      {super.key,
      required this.authorName,
      required this.postedAt,
      required this.profileImageUrl});

  @override
  Widget build(BuildContext context) {
    double fontSize = convertPixle(14, "width", context);
    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceBetween,
      children: [
        Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            Padding(
              padding: const EdgeInsets.only(right: 10),
              child: ArticleAuthorProfilePicture(
                profileImage: profileImageUrl,
              ),
            ),
            Column(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(
                  authorName,
                  style: TextStyle(
                    fontSize: fontSize,
                    color: secondaryTextColor,
                    fontFamily: 'Urbanist',
                  ),
                ),
                Text(
                  "$postedAt ago",
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
      ],
    );
  }
}
