import 'package:flutter/material.dart';
import 'package:matador/features/article/presentation/widgets/article_detail.dart';
import 'package:matador/features/article/presentation/widgets/user_card.dart';

class ArticleReading extends StatelessWidget {
  const ArticleReading({super.key});
  @override
  Widget build(BuildContext context) {
    String articleDescription =
        "very long text goes here. very long text goes here. very long text goes here. very long text goes here.  very long text goes here. very long text goes here. very long text goes here.  very long text goes here. I will copy and paste long text here and see what happens. In the above example, we're using the Stack widget to position two Text widgets on top of each other. We're also using the Positioned widget to specify the position of each Text widget within the Stack. The alignment property of the Stack widget is used to specify the default alignment of the widgets within the Stack. In this case, we're using Alignment.center to center the widgets within the Stack. very long text goes here. I will copy and paste long text here and see what happens. In the above example, we're using the Stack widge to position two Text widgets on top of each other.";
    double width = MediaQuery.of(context).size.width;
    double height = MediaQuery.of(context).size.height;
    return Scaffold(
      body: SingleChildScrollView(
        child: Column(
          children: [
            // header goes here.
            Padding(
              padding: EdgeInsets.only(
                  left: width * 0.133,
                  right: width * 0.133,
                  top: height * 0.08867,
                  bottom: height * 0.027),
              child: Column(
                mainAxisAlignment: MainAxisAlignment.spaceAround,
                children: [
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      // back icon button
                      Icon(Icons.chevron_left),
                      // three dots icon button
                      Icon(Icons.more_horiz)
                    ],
                  ),
                  SizedBox(height: height * 0.0369),
                  // header Text goes here
                  Text(
                    "Four Things Everyone Needs To Know",
                    style: TextStyle(fontSize: 24, fontWeight: FontWeight.w600),
                  ),
                  SizedBox(height: height * 0.032),

                  // User card goes here. should be implemented in widgets folder.
                  UserCard(
                      imageUrl: "assets/images/profile_image.jpg",
                      name: "Rechard Gervan",
                      postedTime: "2m ago"),
                ],
              ),
            ),

            // Article detail card. should be a stack as we need Like icon button on it.
            ArticleDetail(
              imageUrl: "assets/images/article_detail.jpg",
              text: articleDescription,
              likes: "2.1K",
            )
          ],
        ),
      ),
    );
  }
}
