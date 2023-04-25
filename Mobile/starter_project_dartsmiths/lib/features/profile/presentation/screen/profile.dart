import 'package:flutter/material.dart';

import '../../../../core/utils/app _ textstyle.dart';
import '../../../../core/utils/app_color.dart';
import '../widgets/about_me.dart';
import '../widgets/my_posts.dart';

class Profile extends StatelessWidget {
  const Profile({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: AppColor.background,
      body: SingleChildScrollView(
        scrollDirection: Axis.vertical,
        child: Column(
          children: [
            Padding(
              padding: EdgeInsets.only(
                top: MediaQuery.of(context).size.width * (1 / 7),
                left: MediaQuery.of(context).size.width * (1 / 10),
                right: MediaQuery.of(context).size.width * (1 / 10),
              ),
              child: Row(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: [
                    Text("Profile",
                        style: MyStyle.copyWith(
                            fontSize: 21,
                            fontWeight: FontWeight.w500,
                            fontStyle: FontStyle.normal)),
                    Icon(
                      Icons.more_horiz,
                      size: 30,
                    )
                  ]),
            ),
            const AboutMe(),
            SizedBox(
              height: MediaQuery.of(context).size.height * (1 / 25),
            ),
            const MyPosts(),
          ],
        ),
      ),
    );
  }
}
