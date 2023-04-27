import 'package:dark_knights/features/feeds/presentation/widgets/action_button.dart';
import 'package:flutter/material.dart';
import '../widgets/article_card.dart';
import '../widgets/filters.dart';
import '../widgets/profile_pic.dart';
import '../widgets/search_bar.dart';
import '../../../../core/utils/colors.dart';

class HomePage extends StatelessWidget {
  const HomePage({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    final screenWidth = MediaQuery.of(context).size.width;
    final screenHeight = MediaQuery.of(context).size.height;
    return Scaffold(
      backgroundColor: homeBackgroundColor,
      body: SingleChildScrollView(
        child: SafeArea(
            child: Column(
          crossAxisAlignment: CrossAxisAlignment.end,
          children: [
            Padding(
              padding: EdgeInsets.fromLTRB(screenWidth * 0.03,
                  screenHeight * 0.03, screenWidth * 0.03, screenHeight * 0.01),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  InkWell(
                    child: Image.asset("assets/images/menu.png"),
                  ),
                  Text(
                    "Welcome Back!",
                    style: TextStyle(
                        fontSize: screenWidth * 0.07,
                        fontFamily: "Poppins",
                        fontWeight: FontWeight.w700),
                  ),
                  const ProfilePic()
                ],
              ),
            ),
            const SearchBar(),
            Padding(
              padding: EdgeInsets.all(screenWidth * 0.02),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                children: [
                  Filters(
                    lable: "All",
                    active: true,
                  ),
                  Filters(
                    lable: "Sports",
                  ),
                  Filters(
                    lable: "Tech",
                  ),
                  Filters(
                    lable: "Politics",
                  ),
                ],
              ),
            ),
            Padding(
              padding: EdgeInsets.all(screenHeight * 0.02),
              child: const ArticleCard(),
            ),
            Padding(
              padding: EdgeInsets.all(screenHeight * 0.02),
              child: const ArticleCard(),
            ),
            Padding(
                padding: EdgeInsets.fromLTRB(
                    0, 0, screenWidth * 0.04, screenWidth * 0.02),
                child: const ActionButton(height: 60, child: Icon(Icons.add)))
          ],
        )),
      ),
    );
  }
}
