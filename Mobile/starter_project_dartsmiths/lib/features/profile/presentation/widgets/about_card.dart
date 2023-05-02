import 'package:dartsmiths/core/utils/colors.dart';
import 'package:flutter/material.dart';

import '../../../../core/utils/app_textstyle.dart';
import 'status_card.dart';

class AboutCard extends StatelessWidget {
  const AboutCard({super.key});

  @override
  Widget build(BuildContext context) {
    var userName = "@joviedan";
    var name = "Jovi Daniel";
    var job = "UX Designer";
    var description =
        "Madison Blackstone is a director of user experience design, with experience managing global teams.";
    var url =
        "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSj2j9hRj3vyP_BiTwRy9GHPD3yVvP9nt0GoQ&usqp=CAU";
    return Stack(alignment: Alignment.bottomCenter, children: [
      Padding(
        padding: EdgeInsets.all(MediaQuery.of(context).size.width * (1 / 10)),
        child: Container(
          decoration: BoxDecoration(
              color: whiteColor, borderRadius: BorderRadius.circular(13)),
          height: MediaQuery.of(context).size.height * (1 / 3.1),
          child: Padding(
            padding:
                EdgeInsets.all(MediaQuery.of(context).size.width * (1 / 18)),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Row(
                  children: [
                    Container(
                      decoration: BoxDecoration(
                          border: Border.all(width: 2, color: primaryColor),
                          borderRadius: BorderRadius.circular(
                              MediaQuery.of(context).size.width * (1 / 14))),
                      child: Padding(
                        padding: EdgeInsets.all(
                            MediaQuery.of(context).size.width * (1 / 60)),
                        child: Container(
                          height:
                              MediaQuery.of(context).size.width * 1 / 5 * 0.9,
                          width:
                              MediaQuery.of(context).size.width * 1 / 5 * 0.9,
                          decoration: BoxDecoration(
                              borderRadius: BorderRadius.circular(
                                  MediaQuery.of(context).size.width * (1 / 18)),
                              image: DecorationImage(
                                fit: BoxFit.cover,
                                image: NetworkImage(url),
                              )),
                        ),
                      ),
                    ),
                    SizedBox(
                      width: MediaQuery.of(context).size.width * (1 / 12),
                    ),
                    Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Text(userName,
                            style: profileTextStyle.copyWith(
                                fontSize: 17,
                                fontWeight: FontWeight.w700,
                                fontStyle: FontStyle.italic)),
                        Text(name,
                            style: profileTextStyle.copyWith(
                                fontWeight: FontWeight.w300,
                                fontStyle: FontStyle.italic)),
                        SizedBox(
                          height:
                              MediaQuery.of(context).size.height * (1 / 100),
                        ),
                        Text(
                          job,
                          style: profileTextStyle.copyWith(
                            fontSize: 17,
                            color: primaryColor,
                            fontWeight: FontWeight.w200,
                            fontStyle: FontStyle.italic,
                          ),
                        )
                      ],
                    )
                  ],
                ),
                SizedBox(height: MediaQuery.of(context).size.height * (1 / 40)),
                Text("About me",
                    style: profileTextStyle.copyWith(
                        fontSize: 17,
                        fontWeight: FontWeight.w200,
                        fontStyle: FontStyle.italic)),
                SizedBox(
                  height: MediaQuery.of(context).size.height * (1 / 80),
                ),
                Text(description,
                    style: profileTextStyle.copyWith(
                        fontSize: 15.4,
                        fontWeight: FontWeight.w200,
                        fontStyle: FontStyle.italic)),
              ],
            ),
          ),
        ),
      ),
      const StatusCard()
    ]);
  }
}
