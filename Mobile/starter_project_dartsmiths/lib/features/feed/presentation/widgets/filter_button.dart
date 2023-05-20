import 'package:dartsmiths/core/utils/colors.dart';
import 'package:dartsmiths/core/utils/style.dart';
import 'package:dartsmiths/features/feed/presentation/bloc/home_bloc.dart';
import 'package:dartsmiths/features/feed/presentation/bloc/home_event.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../../../../core/utils/ui_converter.dart';

class FilterButton extends StatefulWidget {
  const FilterButton({super.key});

  @override
  State<FilterButton> createState() => _FilterButtonState();
}

class _FilterButtonState extends State<FilterButton> {
  List<String> filterText = ["All", "Sports", "Tech", "Politics"];

  int selectedIndex = 0;
  @override
  Widget build(BuildContext context) {
    return SizedBox(
      height: UIConverter.getComponentHeight(context, 45),
      child: ListView.builder(
          scrollDirection: Axis.horizontal,
          itemCount: filterText.length,
          itemBuilder: (BuildContext context, int index) {
            return TextButton(
              onPressed: () => {
                selectedIndex = index,
                context
                    .read<SearchBloc>()
                    .add(SearchTagChanged(tag: filterText[index])),
                
              },
              child: Container(
                decoration: BoxDecoration(
                    color: index == selectedIndex ? primaryColor : whiteColor,
                    borderRadius: BorderRadius.circular(
                        UIConverter.getComponentWidth(context, 35)),
                    border: Border.all(
                      color: primaryColor,
                      width: UIConverter.getComponentWidth(context, 2),
                    )),
                width: UIConverter.getComponentWidth(context, 65),
                height: UIConverter.getComponentHeight(context, 45),
                child: Center(
                    child: Text(filterText[index],
                        style: selectedIndex == index
                            ? myTextStyle.copyWith(color: whiteColor)
                            : myTextStyle.copyWith(color: primaryColor))),
              ),
            );
          }),
    );
  }
}
