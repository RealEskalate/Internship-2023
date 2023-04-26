import 'package:dartsmiths/core/utils/app_textstyle.dart';
import 'package:dartsmiths/core/utils/colors.dart';
import 'package:flutter/material.dart';
import 'post_card.dart';

class MyPosts extends StatelessWidget {
  const MyPosts({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      decoration: BoxDecoration(
          color: whiteColor,
          borderRadius: BorderRadius.only(
              topLeft: Radius.circular(22), topRight: Radius.circular(22))),
      child: Padding(
        padding: const EdgeInsets.symmetric(horizontal: 40, vertical: 30),
        child: Column(
          children: [
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Text("My Posts",
                    style: MyStyle.copyWith(
                        fontSize: 21, fontWeight: FontWeight.w500)),
                Row(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: [
                    Icon(
                      Icons.grid_view_outlined,
                      color: primaryColor,
                      size: 30,
                    ),
                    SizedBox(
                      width: MediaQuery.of(context).size.height * (1 / 40),
                    ),
                    Icon(
                      Icons.menu_outlined,
                      color: primaryColor,
                      size: 30,
                    )
                  ],
                )
              ],
            ),
            SizedBox(
              height: MediaQuery.of(context).size.height * (1 / 50),
            ),
            Column(
              children: [
                PostCard(
                  img:
                      'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSj2j9hRj3vyP_BiTwRy9GHPD3yVvP9nt0GoQ&usqp=CAU',
                  likes: '2.1k',
                  time: '1hr ago',
                  title:
                      'Why Big Data Needs Thick Data? hkjibibuyvtuctrfderfgthjkfgvbhjnmkvszdxf',
                  topic: 'BIG DATA',
                  saved: true,
                ),
                PostCard(
                  img:
                      'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSj2j9hRj3vyP_BiTwRy9GHPD3yVvP9nt0GoQ&usqp=CAU',
                  likes: '2.1k',
                  time: '1hr ago',
                  title: 'Step Design Sprint for UX Beginner',
                  topic: 'UX DESIGN',
                  saved: true,
                ),
              ],
            )
          ],
        ),
      ),
    );
  }
}
