using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LucKee
{
    [RequireComponent(typeof(RectTransform))]
    public class CanvasRegent : MonoBehaviour
    {
        public static CanvasRegent Instance { get; private set; }
        public static Rect AvailableArea { get; private set; }
        [SerializeField]
        private GapFiller gapPrefab = null;

        private Canvas canvas = null;
        private void Awake()
        {
            Instance = this;

            RectTransform rectT = GetComponent<RectTransform>();
            Rect rect = rectT.rect;
            Vector2 screen = new(Screen.width, Screen.height);
            Vector2 rowSize = rectT.sizeDelta;
            float screenAspect = screen.x / screen.y;
            float selfAspect = rowSize.x / rowSize.y;

            if (screenAspect == selfAspect)
            {
                rectT.localScale *= screen.y / rowSize.y;
            }
            else if (screenAspect > selfAspect)
            {
                rectT.localScale *= screen.y / rowSize.y;
                FillHorizontal(rectT.localScale.x * rect.width);
            }
            else
            {
                rectT.localScale *= screen.x / rowSize.x;
                FillVertical(rectT.localScale.y * rect.height);
            }

            rect.size *= rectT.localScale.x;
            AvailableArea = rect;
        }
        private void FindCanvas()
        {
            if (canvas != null)
            {
                return;
            }
            Transform trans = transform;
            while ((trans = trans.parent) != null)
            {
                canvas = trans.GetComponent<Canvas>();
                if (canvas != null)
                {
                    return;
                }
            }
            canvas = FindAnyObjectByType<Canvas>();
        }
        private void CreateGap(Rect rect)
        {
            if (canvas == null)
            {
                FindCanvas();
            }
            GapFiller gap = Instantiate(gapPrefab, canvas.transform);
            gap.Fill(rect);
        }
        private void FillVertical(float selfHeight)
        {
            float height = (Screen.height - selfHeight) * 0.5f;
            Rect rect = new()
            {
                xMin = 0,
                xMax = Screen.width,
                yMin = Screen.height - height,
                yMax = Screen.height
            };

            CreateGap(rect);

            rect.yMin = 0;
            rect.yMax = height;

            CreateGap(rect);

        }
        private void FillHorizontal(float selfWidth)
        {
            float width = (Screen.width - selfWidth) * 0.5f;
            Rect rect = new()
            {
                yMin = 0,
                yMax = Screen.height,
                xMin = Screen.width - width,
                xMax = Screen.width
            };

            CreateGap(rect);

            rect.xMin = 0;
            rect.xMax = width;

            CreateGap(rect);
        }
    }
}
