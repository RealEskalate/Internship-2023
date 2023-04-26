import 'package:dartsmiths/core/utils/app_textstyle.dart';
import 'package:dartsmiths/core/utils/colors.dart';
import 'package:flutter/material.dart';

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
        height: MediaQuery.of(context).size.width * (1 / 5.2),
        padding: EdgeInsets.only(right: 10),
        decoration: BoxDecoration(boxShadow: [
          BoxShadow(
            color: tertiaryColor,
            spreadRadius: 1,
            blurRadius: 15,
            offset: const Offset(0, 15),
          ),
        ], color: primaryColor, borderRadius: BorderRadius.circular(14)),
        child: Center(
          child: Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              Container(
                decoration: BoxDecoration(
                    color: darkPrimaryColor,
                    borderRadius: BorderRadius.circular(14)),
                child: Padding(
                  padding:
                      const EdgeInsets.symmetric(horizontal: 30, vertical: 15),
                  child: Column(
                    children: [
                      Text(post,
                          style: ProfileTextStyle.copyWith(
                            fontSize: 20,
                            color: whiteColor,
                            fontWeight: FontWeight.w400,
                          )),
                      Text("Post",
                          style: ProfileTextStyle.copyWith(
                            fontSize: 14,
                            color: whiteColor,
                            fontWeight: FontWeight.w300,
                          ))
                    ],
                  ),
                ),
              ),
              Container(
                  child: Padding(
                padding: const EdgeInsets.symmetric(vertical: 15),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.center,
                  children: [
                    Text(follower,
                        style: ProfileTextStyle.copyWith(
                          fontSize: 20,
                          color: whiteColor,
                          fontWeight: FontWeight.w400,
                        )),
                    Text("Following",
                        style: ProfileTextStyle.copyWith(
                          fontSize: 14,
                          color: whiteColor,
                          fontWeight: FontWeight.w300,
                        ))
                  ],
                ),
              )),
              Container(
                  child: Padding(
                padding: const EdgeInsets.symmetric(vertical: 15),
                child: Column(
                  children: [
                    Text(following,
                        style: ProfileTextStyle.copyWith(
                          fontSize: 20,
                          color: whiteColor,
                          fontWeight: FontWeight.w400,
                        )),
                    Text("Followers",
                        style: ProfileTextStyle.copyWith(
                          fontSize: 14,
                          color: whiteColor,
                          fontWeight: FontWeight.w300,
                        ))
                  ],
                ),
              ))
            ],
          ),
        ),
      ),
    );
  }
}
