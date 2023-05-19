import 'package:dartsmiths/core/utils/colors.dart';
import 'package:dartsmiths/core/utils/style.dart';
import 'package:dartsmiths/core/utils/ui_converter.dart';
import 'package:dartsmiths/features/feed/presentation/bloc/home_bloc.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class Searchbar extends StatelessWidget {
  Searchbar({super.key, required this.controller});
  TextEditingController controller;
  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: EdgeInsets.only(
          left: UIConverter.getComponentWidth(context, 15),
          right: UIConverter.getComponentWidth(context, 15),
          top: UIConverter.getComponentHeight(context, 20),
          bottom: UIConverter.getComponentHeight(context, 10)),
      child: Container(
        width: double.infinity,
        height: UIConverter.getComponentHeight(context, 60),
        decoration: BoxDecoration(
          boxShadow: [
            BoxShadow(
              color: Colors.grey.withOpacity(0.3),
              spreadRadius: UIConverter.getComponentWidth(context, 5),
              blurRadius: UIConverter.getComponentWidth(context, 9),
              offset: Offset(UIConverter.getComponentWidth(context, 0),
                  UIConverter.getComponentHeight(context, 9)),
            )
          ],
          borderRadius:
              BorderRadius.circular(UIConverter.getComponentWidth(context, 10)),
        ),
        child: Container(
          decoration: BoxDecoration(
            color: whiteColor,
            borderRadius: BorderRadius.circular(
                UIConverter.getComponentWidth(context, 10)),
          ),
          width: double.infinity,
          height: UIConverter.getComponentHeight(context, 220),
          child: Padding(
            padding: EdgeInsets.only(
                left: UIConverter.getComponentWidth(context, 15)),
            child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  Container(
                    color: whiteColor,
                    width: UIConverter.getComponentWidth(context, 290),
                    height: UIConverter.getComponentHeight(context, 60),
                    child: TextField(
                      onSubmitted: (value) {
                        controller.text = value;
                        context.read<HomeBloc>()
                          .add(SearchEvent(controller.text, 'Techs'));
                      },
                      decoration: InputDecoration(
                        hintText: "Search and article ..",
                        hintStyle: myTextStyle.copyWith(
                          letterSpacing:
                              UIConverter.getComponentWidth(context, 1),
                          fontWeight: FontWeight.w100,
                          fontSize: UIConverter.getComponentWidth(context, 10),
                          color: Colors.grey,
                        ),
                        border: InputBorder.none,
                      ),
                      style: myTextStyle.copyWith(
                        letterSpacing:
                            UIConverter.getComponentWidth(context, 1),
                        fontWeight: FontWeight.w100,
                        fontSize: UIConverter.getComponentWidth(context, 10),
                        color: Colors.grey,
                      ),
                    ),
                  ),
                  Container(
                    decoration: BoxDecoration(
                        color: secondaryColor,
                        borderRadius: BorderRadius.circular(
                            UIConverter.getComponentWidth(context, 10))),
                    width: UIConverter.getComponentWidth(context, 40),
                    height: UIConverter.getComponentHeight(context, 60),
                    child: IconButton(
                        onPressed: () => {},
                        icon: Icon(
                          size: UIConverter.getComponentWidth(context, 20),
                          Icons.search_sharp,
                          color: whiteColor,
                        )),
                  ),
                ]),
          ),
        ),
      ),
    );
  }
}
