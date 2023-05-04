import 'package:flutter/material.dart';
import 'package:matador/features/Article/presentation/widgets/article_detail.dart';
import 'package:matador/features/Article/presentation/widgets/user_card.dart';

class ArticleReading extends StatelessWidget {
  const ArticleReading({super.key});

  @override
  Widget build(BuildContext context) {
    double width = MediaQuery.of(context).size.width;
    double height = MediaQuery.of(context).size.height;
    return Scaffold(
      body: SingleChildScrollView(
        child: Column(
          children: [
            // header goes here.
            Padding(
              padding: EdgeInsets.only(
                  left: width * 0.133, right:  width * 0.133, top: height * 0.08867, bottom: height * 0.027),
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
            ArticleDetail(imageUrl: "assets/images/article_detail.jpg", text: "long text goes here.", likes: "2.1K",)
          ],
        ),
      ),
    );
  }
}
