import 'package:dark_knights/core/utils/colors.dart';
import 'package:dark_knights/core/utils/converter.dart';
import 'package:dark_knights/features/article%20reading/presentation/widgets/Article_Author_Profile_Picture.dart';
import 'package:dark_knights/features/article%20reading/presentation/widgets/Article_Like_Button.dart';
import 'package:flutter/material.dart';

class ArticleAuthorDetail extends StatelessWidget {
  final String authorName;
  final String postedAt;
  const ArticleAuthorDetail(
      {super.key, required this.authorName, required this.postedAt});

  @override
  Widget build(BuildContext context) {
    double fontSize = convertPixle(14, "width", context);
    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceBetween,
      children: [
        Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            const Padding(
              padding: EdgeInsets.only(right: 10),
              child: ArticleAuthorProfilePicture(),
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
