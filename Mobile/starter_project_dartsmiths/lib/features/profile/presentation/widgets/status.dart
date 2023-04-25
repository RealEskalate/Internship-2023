import 'package:dartsmiths/core/utils/app%20_%20textstyle.dart';
import 'package:flutter/material.dart';

import '../../../../core/utils/app_color.dart';

class Status extends StatelessWidget {
  const Status({super.key});

  @override
  Widget build(BuildContext context) {
    var post = "52";
    var follower = "250";
    var following = "4.5K";
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 70),
      child: Container(
        padding: EdgeInsets.only(right: 10),
        decoration: BoxDecoration(boxShadow: [
          BoxShadow(
            color: AppColor.shadow,
            spreadRadius: 1,
            blurRadius: 15,
            offset: const Offset(0, 15),
          ),
        ], color: AppColor.violet, borderRadius: BorderRadius.circular(14)),
        child: Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            Container(
              decoration: BoxDecoration(
                  color: AppColor.violetDark,
                  borderRadius: BorderRadius.circular(14)),
              child: Padding(
                padding:
                    const EdgeInsets.symmetric(horizontal: 30, vertical: 15),
                child: Column(
                  children: [
                    Text(post,
                        style: MyStyle.copyWith(
                          fontSize: 20,
                          color: Colors.white,
                          fontWeight: FontWeight.w400,
                        )),
                    Text("Post",
                        style: MyStyle.copyWith(
                          fontSize: 14,
                          color: Colors.white,
                          fontWeight: FontWeight.w300,
                        ))
                  ],
                ),
              ),
            ),
            Container(
              child: Column(
                children: [
                  Text(follower,
                      style: MyStyle.copyWith(
                        fontSize: 20,
                        color: Colors.white,
                        fontWeight: FontWeight.w400,
                      )),
                  Text("Following",
                      style: MyStyle.copyWith(
                        fontSize: 14,
                        color: Colors.white,
                        fontWeight: FontWeight.w300,
                      ))
                ],
              ),
            ),
            Container(
              child: Column(
                children: [
                  Text(following,
                      style: MyStyle.copyWith(
                        fontSize: 20,
                        color: Colors.white,
                        fontWeight: FontWeight.w400,
                      )),
                  Text("Followers",
                      style: MyStyle.copyWith(
                        fontSize: 14,
                        color: Colors.white,
                        fontWeight: FontWeight.w300,
                      ))
                ],
              ),
            )
          ],
        ),
      ),
    );
  }
}
