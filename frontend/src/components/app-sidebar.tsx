import { Calculator, Plus, Minus, Divide, Radical, X, ChevronUp } from "lucide-react";
import {
  Sidebar,
  SidebarContent,
  SidebarFooter,
  SidebarGroup,
  SidebarGroupContent,
  SidebarGroupLabel,
  SidebarMenu,
  SidebarMenuButton,
  SidebarMenuItem,
} from "@/components/ui/sidebar";
import { ModeToggle } from "@/components/theme/mode-toggle";

// Menu items.
const items = [
  {
    title: "Expression calculator",
    url: "#",
    icon: Calculator,
  },
  {
    title: "Sum calculator",
    url: "#",
    icon: Plus,
  },
  {
    title: "Subtract calculator",
    url: "#",
    icon: Minus,
  },
  {
    title: "Multiply calculator",
    url: "#",
    icon: X,
  },
  {
    title: "Divide calculator",
    url: "#",
    icon: Divide,
  },
  {
    title: "Pow calculator",
    url: "#",
    icon: ChevronUp,
  },
  {
    title: "Sqrt calculator",
    url: "#",
    icon: Radical,
  },
];

export function AppSidebar() {
  return (
    <Sidebar collapsible="icon">
      <SidebarContent>
        <SidebarGroup>
          <SidebarGroupLabel>All calculators</SidebarGroupLabel>
          <SidebarGroupContent>
            <SidebarMenu>
              {items.map((item) => (
                <SidebarMenuItem key={item.title}>
                  <SidebarMenuButton asChild>
                    <a href={item.url}>
                      <item.icon />
                      <span>{item.title}</span>
                    </a>
                  </SidebarMenuButton>
                </SidebarMenuItem>
              ))}
            </SidebarMenu>
          </SidebarGroupContent>
        </SidebarGroup>
      </SidebarContent>

      <SidebarFooter className="items-center">
        <ModeToggle />
      </SidebarFooter>
    </Sidebar>
  );
}
