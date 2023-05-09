import 'package:dark_knights/features/feeds/presentation/widgets/action_button.dart';
import 'package:flutter/material.dart';
import '../widgets/article_card.dart';
import '../widgets/filters.dart';
import '../widgets/profile_pic.dart';
import '../widgets/search_bar.dart';
import '../../../../core/utils/colors.dart';

class HomePage extends StatelessWidget {
  HomePage({
    super.key,
  });
  final List<String> filters = [
    "All",
    "Sports",
    "Tech",
    "Politics",
  ];
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
                padding: EdgeInsets.only(
                    left: screenWidth * 0.08, right: screenWidth * 0.08),
                child: SizedBox(
                  height: screenHeight * 0.07,
                  child: ListView.separated(
                      scrollDirection: Axis.horizontal,
                      itemBuilder: (BuildContext context, int index) {
                        return Filters(
                          label: filters[index],
                          active: index == 0,
                        );
                      },
                      separatorBuilder: (context, index) => SizedBox(
                            width: screenWidth * 0.05,
                          ),
                      itemCount: filters.length),
                )),
            Padding(
              padding: EdgeInsets.all(screenHeight * 0.02),
              child: const ArticleCard(
                articleTitle:
                    "STUDENTS SHOULD WORK ON IMPROVING THEIR WRITING SKILL",
                author: "By John Doe",
                articleType: "Education",
                readTime: 20,
                publishedDate: "Jan 12,2022",
              ),
            ),
            Padding(
              padding: EdgeInsets.all(screenHeight * 0.02),
              child: const ArticleCard(
                articleTitle: "WHY IS ANIME THE BEST THING IN THE WORLD",
                author: "By Simon Mekonnen",
                articleType: "Education",
                readTime: 20,
                publishedDate: "Jan 12,2022",
              ),
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
