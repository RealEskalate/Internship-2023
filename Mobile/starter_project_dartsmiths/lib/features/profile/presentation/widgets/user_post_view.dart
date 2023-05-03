import 'package:dartsmiths/core/utils/app_textstyle.dart';
import 'package:dartsmiths/core/utils/colors.dart';
import 'package:flutter/material.dart';
import 'post_card.dart';

class UserPostView extends StatelessWidget {
  UserPostView({super.key});

  List posts = [
    PostModel(
      img:
          'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSj2j9hRj3vyP_BiTwRy9GHPD3yVvP9nt0GoQ&usqp=CAU',
      likes: '2.1k',
      time: '1hr ago',
      title:
          'Why Big Data Needs Thick Data? hkjibibuyvtuctrfderfgthjkfgvbhjnmkvszdxf',
      topic: 'BIG DATA',
      saved: true,
    ),
    PostModel(
      img:
          'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSj2j9hRj3vyP_BiTwRy9GHPD3yVvP9nt0GoQ&usqp=CAU',
      likes: '2.1k',
      time: '1hr ago',
      title: 'Step Design Sprint for UX Beginner',
      topic: 'UX DESIGN',
      saved: true,
    ),
  ];

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
                    style: profileTextStyle.copyWith(
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
            Container(
              child: ListView.builder(
                  itemCount: posts.length,
                  shrinkWrap: true,
                  itemBuilder: (context, index) {
                    return PostCard(
                        img: posts[index].img,
                        topic: posts[index].topic,
                        title: posts[index].title,
                        likes: posts[index].likes,
                        time: posts[index].time);
                  }),
            )
          ],
        ),
      ),
    );
  }
}

class PostModel {
  final String img;
  final String topic;
  final String title;
  final String likes;
  final String time;
  final bool saved;

  PostModel({
    required this.img,
    required this.topic,
    required this.title,
    required this.likes,
    required this.time,
    required this.saved,
  });
}
